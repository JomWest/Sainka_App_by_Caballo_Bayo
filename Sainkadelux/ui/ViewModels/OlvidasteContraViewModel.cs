using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sainkadelux.domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sainkadelux.ui.ViewModels
{
    public partial class OlvidasteContraViewModel(IFirebaseAuthRepository firebaseAuthRepository,
        INavigationService navigationService) : ObservableObject
    {
        [ObservableProperty]
        private string _email = "";

        [ObservableProperty]
        private string _errorMessage = "";

        [RelayCommand]
        public async Task SendResetEmail()
        {
            try
            {
                await firebaseAuthRepository.SendPasswordResetEmailAsync(Email);

                ErrorMessage = "Se ha enviado un correo para que restablezca su contraseña";

                await navigationService.PopUpNavigation();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
