namespace Sainkadelux.ui.Niveles.Abecedario.Letra_D;

public partial class LetraD : ContentPage
{
    private string[] imagesA = { "dv.png", "dlv.png" };
    private int currentImageIndex = 0;
    public LetraD()
	{
		InitializeComponent();
        ChangeImageWithAnimation();

    }
    private async void ChangeImageWithAnimation()
    {
        while (true)
        {
            await animatedImageA.FadeTo(0, 500);

            currentImageIndex = (currentImageIndex + 1) % imagesA.Length;
            animatedImageA.Source = imagesA[currentImageIndex];


            await animatedImageA.FadeTo(1, 500);

            await Task.Delay(2000);
        }
    }
    private async void NivelOneClicked(object sender, EventArgs e)
    {
        Navigation.InsertPageBefore(new LevelPage1D(), this);
        await Navigation.PopAsync();

    }
}