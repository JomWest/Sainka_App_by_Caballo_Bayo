using Microsoft.Maui.Controls;
using Sainkadelux.ui.ViewModels;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
namespace Sainkadelux;

public partial class CamaraPage : ContentPage
{

    private CamaraPageViewModel _viewModel;

    private bool _isCapturing = true;
    public CamaraPage()
    {
        InitializeComponent();
        _viewModel = new CamaraPageViewModel();
        BindingContext = _viewModel;
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
            while (_viewModel.IsCapturing)
            {
                try
                {
                    if (cameraView.IsAvailable)
                    {
                        // Llama a CaptureImage y espera el evento MediaCaptured
                        await cameraView.CaptureImage(CancellationToken.None);
                        _viewModel.Counter++;
                    }
                    else
                    {
                        Console.WriteLine("Error: Camera is not available.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                await Task.Delay(5000); // Espera 5 segundos antes de capturar la siguiente imagen
            }
        }
    }

    // Manejar el evento MediaCaptured
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

        // Envía el Stream al ViewModel para su procesamiento
        await _viewModel.ProcessCapturedImage(memoryStream);

        // Actualiza la imagen capturada en la UI
        Dispatcher.Dispatch(() =>
        {
            capturedImage.Source = ImageSource.FromStream(() => new MemoryStream(memoryStream.ToArray()));
        });
    }
}