using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json.Linq;
using Sainkadelux.di;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sainkadelux.ui.ViewModels
{
    public partial class CamaraPageViewModel : ObservableObject
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public CamaraPageViewModel()
        {
            _httpClient = new HttpClient();
            IsCapturing = true;

            var appConfig = ServiceHelper.GetService<AppConfig>();
            _apiBaseUrl = appConfig.ApiBaseUrl;
        }

        private string oracion = "";

        [ObservableProperty]
        private int _counter = 0;

        // Propiedad que indica si se está capturando o no
        [ObservableProperty]
        private bool _isCapturing;

        // Propiedad que almacena la imagen capturada
        [ObservableProperty]
        private ImageSource _capturedImage;

        // Propiedad que almacena el resultado de la predicción
        [ObservableProperty]
        private string _predictionResult;

        private char[] repetirLetras = { 'E', 'R', 'L', 'C' };

        // Método para procesar la imagen capturada y enviar la solicitud a la API
        public async Task ProcessCapturedImage(Stream imageStream)
        {
            try
            {
                using var content = new MultipartFormDataContent();
                content.Add(new StreamContent(imageStream), "image", "frame.jpg");

                var response = await _httpClient.PostAsync(_apiBaseUrl, content);
                var result = await response.Content.ReadAsStringAsync();

                var jsonResult = JObject.Parse(result);
                var prediction = jsonResult["prediction"].ToString();

                if (result.Contains("mensaje") || prediction.Contains("hand")) return;

                if (oracion.Length <= 0)
                {
                    // Si la oración está vacía, simplemente agrega la predicción
                    oracion = oracion + prediction;
                    PredictionResult = oracion;
                }
                else
                {
                    // Obtén el último carácter de la oración
                    char ultimoCaracter = oracion[oracion.Length - 1];

                    // Verifica si el último carácter es igual al primero de la predicción
                    if (ultimoCaracter == prediction[0])
                    {
                        // Si pertenece a las letras especiales y no ha sido repetida tres veces seguidas
                        if (repetirLetras.Any(letra => prediction.Contains(letra)))
                        {
                            // Verificar si los dos últimos caracteres son iguales al actual (tercera repetición)
                            if (oracion.Length >= 2 && oracion[oracion.Length - 2] == ultimoCaracter)
                            {
                                // No agregues la letra si ya ha aparecido tres veces consecutivas
                                return;
                            }
                            else
                            {
                                // Se puede agregar la letra, ya que no es una repetición de tres veces
                                oracion = oracion + prediction;
                                PredictionResult = oracion;
                            }
                        }
                        else
                        {
                            // Si no pertenece a las letras especiales, no se agrega de nuevo
                            return;
                        }
                    }
                    else
                    {
                        // Si no es el mismo carácter, actualiza el resultado de la predicción
                        oracion = oracion + prediction;
                        PredictionResult = oracion;
                    }
                }

            }
            catch (Exception ex)
            {
                PredictionResult = $"Error: {ex.Message}";
            }
        }

        [RelayCommand]
        public void deleteLetter()
        {
            if (!string.IsNullOrEmpty(PredictionResult)) // Verifica si hay contenido
            {
                PredictionResult = PredictionResult.Remove(PredictionResult.Length - 1);
            }
        }
    }
}
