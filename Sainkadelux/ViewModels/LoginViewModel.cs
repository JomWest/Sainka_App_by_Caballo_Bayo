using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sainkadelux.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sainkadelux.ViewModels
{
    public partial class LoginViewModel(IFirebaseAuthRepository firebaseAuthRepository,
        INavigationService navigationService): ObservableObject
    {

        [ObservableProperty]
        private string _email = "";

        [ObservableProperty]
        private string _password = "";

        [ObservableProperty]
        private string _errorMessage = "";

        [RelayCommand]
        public async Task LoginAsync()
        {
            try
            {
                var credentials = await firebaseAuthRepository.SignInAsync(Email, Password);
                if (credentials != null && credentials.User != null)
                {
                   await navigationService.NavigateToMenuPageAsync();

                }
                else
                {
                    ErrorMessage = "Las credenciales proporcionadas no son válidas.";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("INVALID_LOGIN_CREDENTIALS"))
                {
                    ErrorMessage = "El correo electrónico es incorrecto.";
                }
                else if (ex.Message.Contains("MISSING_EMAIL"))
                {
                    ErrorMessage = "El correo electrónico o la contraseña son incorrectos.";
                }
                else if (ex.Message.Contains("INVALID_EMAIL"))
                {
                    ErrorMessage = "El correo electrónico es incorrecto.";
                }
                else if (ex.Message.Contains("MISSING_PASSWORD"))
                {
                    ErrorMessage = "La contraseña es incorrecta.";
                }
                else
                {
                    ErrorMessage = $"Ocurrió un error: {ex.Message}";
                }
            }
        }
    }
}
