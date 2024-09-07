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
    public partial class RegisterViewModel(
        IFirebaseAuthRepository firebaseAuthRepository,
        INavigationService navigationService) : ObservableObject
    {
        [ObservableProperty]
        private string _name = "";

        [ObservableProperty]
        private string _email = "";

        [ObservableProperty]
        private string _password = "";

        [ObservableProperty]
        private string _rePassword = "";

        [ObservableProperty]
        private string _errorMessage = "";

        [ObservableProperty]
        private string _successMessage = "";

        [RelayCommand]
        public async Task RegisterUser()
        {
            try
            {
                if(string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(RePassword))
                {
                    ErrorMessage = "Todos los campos son obligatorios.";
                    return;
                }
                if (Password != RePassword)
                {
                    ErrorMessage = "Las contraseñas no coinciden.";
                    return;
                }

                var userCredential = await firebaseAuthRepository.CreateUserAsync(Email, Password, Name);
                SuccessMessage = "Usuario registrado exitosamente.";
                await navigationService.NavigateToLoginOptionPageAsync();
                
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Hubo un problema al registrar el usuario: {ex.Message}";
            }
        }
    }
}
