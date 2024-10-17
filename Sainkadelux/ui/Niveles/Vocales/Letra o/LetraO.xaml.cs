namespace Sainkadelux.ui.Niveles.Letra_o;

public partial class LetraO : ContentPage
{
    private string[] imagesO = { "ov.png", "olv.png" };
    private int currentImageIndex = 0;
    public LetraO()
	{
		InitializeComponent();
        ChangeImageWithAnimation();

    }
    private async void ChangeImageWithAnimation()
    {
        while (true)
        {
            await animatedImageO.FadeTo(0, 500);

            currentImageIndex = (currentImageIndex + 1) % imagesO.Length;
            animatedImageO.Source = imagesO[currentImageIndex];


            await animatedImageO.FadeTo(1, 500);

            await Task.Delay(2000);
        }
    }
    private async void NivelOneClicked(object sender, EventArgs e)
    {
        Navigation.InsertPageBefore(new LevelPage1O(), this);
        await Navigation.PopAsync();

    }
}