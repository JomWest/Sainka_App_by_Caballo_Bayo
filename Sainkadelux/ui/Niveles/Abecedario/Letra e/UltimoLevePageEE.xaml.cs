using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Storage;
using Newtonsoft.Json.Linq;
using Sainkadelux.data.Services;
using SkiaSharp.Extended.UI.Controls;

namespace Sainkadelux.ui.Niveles.Abecedario.Letra_e;

public partial class UltimoLevePageEE : ContentPage
{
    private CancellationTokenSource? _cancellationTokenSource;
    private HttpClient _httpClient;
    string _prediction;
    private bool _isCapturing = true;
    private readonly string userId = GlobalUser.UserId;
    private readonly FirebaseConnect _firebase = new FirebaseConnect();
    public UltimoLevePageEE()
	{
		InitializeComponent();
        _httpClient = new HttpClient();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await Task.Delay(2000);

        _isCapturing = true;
        StartCameraCapture();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        _isCapturing = false;
    }

    private async void StartCameraCapture()
    {
        if (cameraView != null)
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
                    else
                    {
                        Console.WriteLine("Error: Camera is not available.\"");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                // Espera 5 segundos antes de capturar la siguiente imagen
                await Task.Delay(3000);
            }
        }
    }
    private async void cameraView_MediaCaptured(object sender, CommunityToolkit.Maui.Views.MediaCapturedEventArgs e)
    {

        if (e.Media == null)
        {
            Console.WriteLine($"Error: No media captured");
            return;
        }

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
            content.Add(new StreamContent(memoryStream), "image", "frame.jpg");

            var response = await _httpClient.PostAsync("http://162.215.175.28:5000/predict", content);
            var result = await response.Content.ReadAsStringAsync();

            var jsonResult = JObject.Parse(result);
            var prediction = jsonResult["prediction"].ToString();

            Dispatcher.Dispatch(() =>
            {
                _prediction = prediction;
                VerificarPrediccion();
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            _prediction = $"error: {ex.Message}";
        }
    }
    private async void VerificarPrediccion()
    {

        if (_prediction == "E")
        {
            LevelStack.IsVisible = false;

            CheckFrame.IsVisible = true;
            SKLottieView fireworksAnimation = (SKLottieView)FindByName("fireworksAnimation");
            if (fireworksAnimation != null)
            {
                if (GlobalUser.currentLevel == 2)
                {
                    var newLevel = GlobalUser.currentLevel + 1;
                    await _firebase.GuardarProgreso(userId, newLevel);
                    GlobalUser.currentLevel = newLevel;
                    cameraView.IsEnabled = false;
                }

                fireworksAnimation.IsVisible = true;
                _isCapturing = false;
            }
            else
            {
                Console.WriteLine("El elemento fireworksAnimation no fue encontrado.");
            }
        }
    }
    private async void Menuclicked(object seder, EventArgs e)
    {
        Navigation.InsertPageBefore(new FirtsAbecedarioPage(), this);
        await Navigation.PopAsync();

    }
}