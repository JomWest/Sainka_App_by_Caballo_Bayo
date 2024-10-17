namespace Sainkadelux.ui.Niveles.Letra_i;

public partial class LetraI : ContentPage
{
    private string[] imagesI = { "iv.png", "ilv.png" };
    private int currentImageIndex = 0;
    public LetraI()
	{
		InitializeComponent();
        ChangeImageWithAnimation();

    }
    private async void ChangeImageWithAnimation()
    {
        while (true)
        {
            await animatedImageI.FadeTo(0, 500);

            currentImageIndex = (currentImageIndex + 1) % imagesI.Length;
            animatedImageI.Source = imagesI[currentImageIndex];


            await animatedImageI.FadeTo(1, 500);

            await Task.Delay(2000);

        }
    }
    private async void Siguientelevelclicked(object sender, EventArgs e)
    {

        Navigation.InsertPageBefore(new LevelPage1I(), this);
        await Navigation.PopAsync();

    }
}