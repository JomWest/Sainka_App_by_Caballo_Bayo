namespace Sainkadelux;

public partial class LeavelPage : ContentPage
{
    private string[] images = { "a.png", "al.png" };
    private string[] imagesE = { "eb.png", "el.png" };
    private string[] imagesI = { "ib.png", "il.png" };
    private string[] imagesO = { "ob.png", "ol.png" };
    private string[] imagesU = { "ub.png", "ul.png" };
    private int currentImageIndex = 0;

    public LeavelPage()
	{

		InitializeComponent();
        ChangeImageWithAnimation();
        ChangeImageWithAnimationE();
        ChangeImageWithAnimationI();
        ChangeImageWithAnimationO();
        ChangeImageWithAnimationU();
    }
    private async void OnImageTapped(object sender, EventArgs e)
    {
        AnimatedFrame.IsVisible = true;
        await AnimatedFrame.TranslateTo(0, 0, 1000, Easing.CubicInOut);
    }
    private async void ChangeImageWithAnimation()
    {
        while (true)
        {

            await animatedImage.FadeTo(0, 500);

            currentImageIndex = (currentImageIndex + 1) % images.Length; 
            animatedImage.Source = images[currentImageIndex];


            await animatedImage.FadeTo(1, 500);

            await Task.Delay(2000); 
        }
    }
    private async void ChangeImageWithAnimationE()
    {
        while (true)
        {

            await animatedImageE.FadeTo(0, 500);

            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageE.Source = imagesE[currentImageIndex];


            await animatedImageE.FadeTo(1, 500);

            await Task.Delay(2000);
        }
    }
    private async void ChangeImageWithAnimationI()
    {
        while (true)
        {

            await animatedImageI.FadeTo(0, 500);

            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageI.Source = imagesI[currentImageIndex];


            await animatedImageI.FadeTo(1, 500);

            await Task.Delay(2000);
        }
    }
    private async void ChangeImageWithAnimationO()
    {
        while (true)
        {

            await animatedImageO.FadeTo(0, 500);

            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageO.Source = imagesO[currentImageIndex];


            await animatedImageO.FadeTo(1, 500);

            await Task.Delay(2000);
        }
    }
    private async void ChangeImageWithAnimationU()
    {
        while (true)
        {

            await animatedImageU.FadeTo(0, 500);

            currentImageIndex = (currentImageIndex + 1) % images.Length;
            animatedImageU.Source = imagesU[currentImageIndex];


            await animatedImageU.FadeTo(1, 500);

            await Task.Delay(2000);
        }
    }
}