namespace Sainkadelux;

public partial class RegistrartePage : ContentPage
{
	FirebaseConnect firebaseConnect = new FirebaseConnect();
	public RegistrartePage()
	{
		InitializeComponent();
	}
    private async void Registrar_Clicked(object sender, EventArgs e)
    {
        string email = CorreoEntry.Text;
        string nombre = NombreEntry.Text;
        string password = Contrase�aEntry.Text;
        string rePassword = ReContrase�aEntry.Text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(rePassword))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
            return;
        }

        if (password != rePassword)
        {
            await DisplayAlert("Error", "Las contrase�as no coinciden.", "OK");
            return;
        }

        try
        {
            var userCredential = await firebaseConnect.CrearUsuario(email, password, nombre);
            await DisplayAlert("�xito", "Usuario registrado exitosamente.", "OK");
            await Navigation.PushAsync( new LoginOptionPage());

  
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Hubo un problema al registrar el usuario: {ex.Message}", "OK");
        }
    }
}