namespace Sainkadelux.ui.Niveles.Letra_u;

public partial class LetraU : ContentPage
{
    private string[] imagesU = { "uv.png", "ulv.png" };
    private int currentImageIndex = 0;
    public LetraU()
	{
		InitializeComponent();
	}
    private async void ChangeImageWithAnimation()
    {
        while (true)
        {
            await animatedImageU.FadeTo(0, 500);

            currentImageIndex = (currentImageIndex + 1) % imagesU.Length;
            animatedImageU.Source = imagesU[currentImageIndex];


            await animatedImageU.FadeTo(1, 500);

            await Task.Delay(2000);
        }
    }
    private async void NivelOneClicked(object sender, EventArgs e)
    {
        Navigation.InsertPageBefore(new LevelPage1U(), this);
        await Navigation.PopAsync();

    }
}