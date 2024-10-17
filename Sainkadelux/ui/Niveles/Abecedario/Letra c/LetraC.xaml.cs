namespace Sainkadelux.ui.Niveles.Abecedario.Letra_c;

public partial class LetraC : ContentPage
{
    private string[] imagesA = { "cv.png", "clv.png" };
    private int currentImageIndex = 0;
    public LetraC()
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
        Navigation.InsertPageBefore(new LevelPage1C(), this);
        await Navigation.PopAsync();

    }
}