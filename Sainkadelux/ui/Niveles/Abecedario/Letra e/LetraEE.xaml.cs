namespace Sainkadelux.ui.Niveles.Abecedario.Letra_e;

public partial class LetraEE : ContentPage
{
    private string[] imagesA = { "ev.png", "elv.png" };
    private int currentImageIndex = 0;
    public LetraEE()
	{
		InitializeComponent();
        ChangeImageWithAnimation();

    }
    private async void ChangeImageWithAnimation()
    {
        while (true)
        {
            await animatedImageE.FadeTo(0, 500);

            currentImageIndex = (currentImageIndex + 1) % imagesA.Length;
            animatedImageE.Source = imagesA[currentImageIndex];


            await animatedImageE.FadeTo(1, 500);

            await Task.Delay(2000);

        }
    }
    private async void Siguientelevelclicked(object sender, EventArgs e)
    {

        Navigation.InsertPageBefore(new LevelPage1EE(), this);
        await Navigation.PopAsync();

    }
}