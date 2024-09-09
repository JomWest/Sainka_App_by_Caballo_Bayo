namespace Sainkadelux;

public partial class OlidasteContraPage : ContentPage
{
	private FirebaseConnect _firebaseConnect;
	public OlidasteContraPage()
	{
		InitializeComponent();
		_firebaseConnect = new FirebaseConnect();
	}

	private async void OnRestablecerClicked(object sender, EventArgs e)
	{
		string email = CorreoEntry.Text;
        if (!string.IsNullOrEmpty(email))
        {
            try
            {
                await _firebaseConnect.EnviarCorreoRestablecimientoContraseña(email);
                await DisplayAlert("Éxito", "Correo de restablecimiento enviado.", "OK");
                await Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", "El correo no esta registrado, intente don un nuevo correo " , "OK");
            }
        }
        else
        {
            await DisplayAlert("Advertencia", "Por favor, ingrese su correo.", "OK");
        }

    }
}