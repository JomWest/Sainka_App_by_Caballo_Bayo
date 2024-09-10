using Sainkadelux.di;
using Sainkadelux.ViewModels;

namespace Sainkadelux;

public partial class RegistrartePage : ContentPage
{
	public RegistrartePage(RegisterViewModel registerViewModel)
	{
		InitializeComponent();
        BindingContext = registerViewModel;
        registerViewModel.PropertyChanged += ViewModel_PropertyChanged;

    }

    private async void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        // Verificamos si la propiedad que cambió fue ErrorMessage
        if (e.PropertyName == nameof(RegisterViewModel.ErrorMessage))
        {
            var viewModel = (RegisterViewModel)BindingContext;

            // Si hay un mensaje de error, mostramos el DisplayAlert
            if (!string.IsNullOrEmpty(viewModel.ErrorMessage))
            {
                await DisplayAlert("Error", viewModel.ErrorMessage, "OK");

                viewModel.ErrorMessage = string.Empty;
            }
            return;
        }

        if(e.PropertyName == nameof(RegisterViewModel.SuccessMessage)){
            var viewModel = (RegisterViewModel)BindingContext;

            if (!string.IsNullOrEmpty(viewModel.SuccessMessage))
            {
                await DisplayAlert("Error", viewModel.SuccessMessage, "OK");

                viewModel.SuccessMessage = string.Empty;
            }
        }

    }
}