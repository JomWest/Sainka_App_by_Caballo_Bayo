using Sainkadelux.data.Services;
using Sainkadelux.ui.ViewModels;
using Sainkadelux.ViewModels;

namespace Sainkadelux;

public partial class OlidasteContraPage : ContentPage
{
    private OlvidasteContraViewModel _olvidasteContraViewModel;
	public OlidasteContraPage(OlvidasteContraViewModel olvidasteContraViewModel)
	{
		InitializeComponent();
        _olvidasteContraViewModel = olvidasteContraViewModel;
        BindingContext = olvidasteContraViewModel;
        olvidasteContraViewModel.PropertyChanged += ViewModel_PropertyChanged;
    }

    private async void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        // Verificamos si la propiedad que cambió fue ErrorMessage
        if (e.PropertyName == nameof(OlvidasteContraViewModel.ErrorMessage))
        {
            var viewModel = (OlvidasteContraViewModel)BindingContext;

            if(!string.IsNullOrEmpty(viewModel.ErrorMessage) && viewModel.ErrorMessage.Contains("Se ha enviado un correo para que restablezca su contraseña")){
                await DisplayAlert("Éxito", viewModel.ErrorMessage, "OK");

                viewModel.ErrorMessage = string.Empty;
                return;
            }

            // Si hay un mensaje de error, mostramos el DisplayAlert
            if (!string.IsNullOrEmpty(viewModel.ErrorMessage))
            {
                await DisplayAlert("Error", viewModel.ErrorMessage, "OK");

                viewModel.ErrorMessage = string.Empty;
            }
            return;
        }
    }
}