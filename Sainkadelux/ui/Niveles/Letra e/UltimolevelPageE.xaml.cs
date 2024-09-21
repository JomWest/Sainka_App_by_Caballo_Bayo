using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
using Newtonsoft.Json.Linq;
using Sainkadelux.data.Services;
using SkiaSharp.Extended.UI.Controls;

namespace Sainkadelux.ui.Niveles.Letra_e;

public partial class UltimolevelPageE : ContentPage
{
    private CancellationTokenSource? _cancellationTokenSource;
    private HttpClient _httpClient;
    string _prediction;
    private bool _isCapturing = true;
    private readonly string userId = GlobalUser.UserId;
    private readonly FirebaseConnect _firebase = new FirebaseConnect();

    public UltimolevelPageE()
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
            await Task.Delay(3000);
        }
    }
    private async void cameraView_MediaCaptured(object sender, CommunityToolkit.Maui.Views.MediaCapturedEventArgs e)
    {
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

            var jsonResult = JObject.Parse(result);
            var prediction = jsonResult["prediccion"].ToString();

            Dispatcher.Dispatch(() =>
            {
                _prediction = prediction;
                VerificarPrediccion();
            });
        }
        catch (Exception ex)
        {
            Dispatcher.Dispatch(async () =>
            {
                await DisplayAlert("error", $"failed to process captured image: {ex.Message}", "ok");
                _prediction = $"error: {ex.Message}";
            });
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
        Navigation.InsertPageBefore(new LeavelPage(), this);
        await Navigation.PopAsync();

    }
}