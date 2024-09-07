using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Sainkadelux.ViewModels;

namespace Sainkadelux
{
    public partial class LoginOptionPage : ContentPage
    {
        public LoginOptionPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private async void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Verificamos si la propiedad que cambió fue ErrorMessage
            if (e.PropertyName == nameof(LoginViewModel.ErrorMessage))
            {
                var viewModel = (LoginViewModel)BindingContext;

                // Si hay un mensaje de error, mostramos el DisplayAlert
                if (!string.IsNullOrEmpty(viewModel.ErrorMessage))
                {
                    await DisplayAlert("Error", viewModel.ErrorMessage, "OK");
                }
            }
        }

        private async void OnRegistrarTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrartePage());
        }
    }
}
