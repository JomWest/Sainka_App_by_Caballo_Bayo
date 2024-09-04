namespace Sainkadelux;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
	}
    private async void OnCameraPageTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CamaraPage());
    }

}