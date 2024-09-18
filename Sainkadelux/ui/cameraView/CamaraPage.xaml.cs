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

    protected override void OnAppearing()
    {
        base.OnAppearing();
        StartCameraCapture();
    }

    private async void StartCameraCapture()
    {
        while (_viewModel.IsCapturing)
        {
            try
            {
                if (cameraView.IsAvailable)
                {
                    // Llama a CaptureImage y espera el evento MediaCaptured
                    await cameraView.CaptureImage(CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Failed to capture image: {ex.Message}", "OK");
            }

            await Task.Delay(5000); // Espera 5 segundos antes de capturar la siguiente imagen
        }
    }

    // Manejar el evento MediaCaptured
    private async void cameraView_MediaCaptured(object sender, CommunityToolkit.Maui.Views.MediaCapturedEventArgs e)
    {
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