using Sainkadelux.di;

namespace Sainkadelux;

public partial class RegistrartePage : ContentPage
{
	FirebaseConnect firebaseConnect = new FirebaseConnect();

    private LoginOptionPage loginOptionPage;
	public RegistrartePage()
	{
		InitializeComponent();
        loginOptionPage = ServiceHelper.GetService<LoginOptionPage>();
	}
    private async void Registrar_Clicked(object sender, EventArgs e)
    {
        string email = CorreoEntry.Text;
        string nombre = NombreEntry.Text;
        string password = ContraseñaEntry.Text;
        string rePassword = ReContraseñaEntry.Text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(rePassword))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        if (password != rePassword)
        {
            await DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
            return;
        }

        try
        {
            var userCredential = await firebaseConnect.CrearUsuario(email, password, nombre);
            await DisplayAlert("Éxito", "Usuario registrado exitosamente.", "OK");
            await Navigation.PushAsync(loginOptionPage);

  
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Hubo un problema al registrar el usuario: {ex.Message}", "OK");
        }
    }
}