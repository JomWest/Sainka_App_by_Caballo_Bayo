namespace Sainkadelux.ui.Niveles.Abecedario.Letra_a;

public partial class LevelPageAA : ContentPage
{
    private string[] imagesA = { "av.png", "alv.png" };
    private int currentImageIndex = 0;
    public LevelPageAA()
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
        Navigation.InsertPageBefore(new Levelpage1AA(), this);
        await Navigation.PopAsync();

    }
}