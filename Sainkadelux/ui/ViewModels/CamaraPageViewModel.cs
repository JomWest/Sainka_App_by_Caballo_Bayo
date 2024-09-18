using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sainkadelux.ui.ViewModels
{
    public partial class CamaraPageViewModel: ObservableObject
    {
        private readonly HttpClient _httpClient;

        public CamaraPageViewModel()
        {
            _httpClient = new HttpClient();
            IsCapturing = true;
        }

        // Propiedad que indica si se está capturando o no
        [ObservableProperty]
        private bool _isCapturing;

        // Propiedad que almacena la imagen capturada
        [ObservableProperty]
        private ImageSource _capturedImage;

        // Propiedad que almacena el resultado de la predicción
        [ObservableProperty]
        private string _predictionResult;

        // Método para procesar la imagen capturada y enviar la solicitud a la API
        public async Task ProcessCapturedImage(Stream imageStream)
        {
            try
            {
                using var content = new MultipartFormDataContent();
                content.Add(new StreamContent(imageStream), "image", "frame.jpg");

                var response = await _httpClient.PostAsync("http://162.215.132.36:5000/predict", content);
                var result = await response.Content.ReadAsStringAsync();

                // Actualiza el resultado de la predicción
                PredictionResult = result;
            }
            catch (Exception ex)
            {
                PredictionResult = $"Error: {ex.Message}";
            }
        }
    }
}
