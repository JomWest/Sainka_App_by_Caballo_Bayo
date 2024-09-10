using Microsoft.Maui.Controls;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
namespace Sainkadelux;

public partial class CamaraPage : ContentPage
{
    private CancellationTokenSource? _cancellationTokenSource;
    private HttpClient _httpClient;

    private bool _isCapturing = true;
    public CamaraPage()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        StartCameraCapture();
    }


    private async void StartCameraCapture()
    {
        while (_isCapturing)
        {
            try
            {
                if (cameraView.IsAvailable)
                {
                    // Llama a CaptureImage, lo cual activará el evento MediaCaptured
                    await cameraView.CaptureImage(CancellationToken.None);
                }

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to capture image: {ex.Message}", "OK");
            }

            // Espera 5 segundos antes de capturar la siguiente imagen
            await Task.Delay(5000);
        }
    }


    private async void cameraView_MediaCaptured(object sender, CommunityToolkit.Maui.Views.MediaCapturedEventArgs e)
    {
        // Crea un MemoryStream en lugar de usar directamente e.Media para evitar problemas de cierre prematuro
        using var memoryStream = new MemoryStream();
        await e.Media.CopyToAsync(memoryStream);
        memoryStream.Position = 0;

        Dispatcher.Dispatch(() =>
        {
            capturedImage.Source = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
        });

        try
        {
            using var content = new MultipartFormDataContent();
            content.Add(new StreamContent(new MemoryStream(memoryStream.ToArray())), "image", "frame.jpg");

            var response = await _httpClient.PostAsync("http://162.215.132.36:5000/predict", content);
            var result = await response.Content.ReadAsStringAsync();

            Dispatcher.Dispatch(() =>
            {
                predictionLabel.Text = $"{result}";
            });
        }
        catch (Exception ex)
        {
            Dispatcher.Dispatch(async () =>
            {
                await DisplayAlert("error", $"failed to process captured image: {ex.Message}", "ok");
                predictionLabel.Text = $"error: {ex.Message}";
            });
        }
    }
    }