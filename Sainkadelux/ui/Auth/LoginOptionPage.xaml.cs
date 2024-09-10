using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Sainkadelux.domain.Repositories;
using Sainkadelux.ViewModels;

namespace Sainkadelux
{
    public partial class LoginOptionPage : ContentPage
    {
        private readonly INavigationService _navigationService;

        public LoginOptionPage(LoginViewModel viewModel, INavigationService navigationService)
        {
            InitializeComponent();
            _navigationService = navigationService;
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

                    viewModel.ErrorMessage = string.Empty;
                }
            }
        }

        private async void OnRegistrarTapped(object sender, EventArgs e)
        {
            await _navigationService.NavigateToRegisterPage();
        }
        private async void OnOlvidasteContraseñaTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OlidasteContraPage());
        }
    }
}
