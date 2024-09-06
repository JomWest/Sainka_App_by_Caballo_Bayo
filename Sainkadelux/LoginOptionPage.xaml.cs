using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Sainkadelux
{
    public partial class LoginOptionPage : ContentPage
    {
        public LoginOptionPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            FirebaseConnect firebaseConnect = new FirebaseConnect();
            string email = CorreoEntry.Text;
            string password = ContraseñaEntry.Text;

            try
            {

                var Credenciales = await firebaseConnect.CargarUsuario(email, password);

                if (Credenciales != null && Credenciales.User != null)
                {
                    var Uid = Credenciales.User.Uid;
                    await Navigation.PushAsync(new MenuPage());
                }
                else
                {
                    await DisplayAlert("Error", "Las credenciales proporcionadas no son válidas.", "OK");
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("INVALID_LOGIN_CREDENTIALS"))
                {
                    await DisplayAlert("Error", "El correo electrónico es incorrecto.", "OK");
                }
                if (ex.Message.Contains("MISSING_EMAIL"))
                {
                    await DisplayAlert("Error", "El correo electrónico o la contraseña son incorrecto.", "OK");
                }
                else if (ex.Message.Contains("MISSING_PASSWORD"))
                {
                    await DisplayAlert("Error", "La contraseña es incorrecta.", "OK");
                }
                else
                {
                    await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
                }
            }
        }
        private async void OnRegistrarTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrartePage());
        }
    }
}
