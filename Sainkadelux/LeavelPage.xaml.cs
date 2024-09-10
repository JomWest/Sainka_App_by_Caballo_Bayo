using Sainkadelux.Niveles.Letra_a;
using Sainkadelux.Repositories;

namespace Sainkadelux;

public partial class LeavelPage : ContentPage
{
    private string[] images = { "a.png", "al.png" };
    private string[] imagesE = { "eb.png", "el.png" };
    private string[] imagesI = { "ib.png", "il.png" };
    private string[] imagesO = { "ob.png", "ol.png" };
    private string[] imagesU = { "ub.png", "ul.png" };
    private int currentImageIndex = 0;

    private readonly string _userId = GlobalUser.UserId;

    private readonly FirebaseConnect _firebase;
    public LeavelPage()
	{

		InitializeComponent();
        ChangeImageWithAnimation();
        ChangeImageWithAnimationE();
        ChangeImageWithAnimationI();
        ChangeImageWithAnimationO();
        ChangeImageWithAnimationU();

        _firebase = new FirebaseConnect();

        getCurrentProgress();
    }

    private async void getCurrentProgress()
    {
        var level = await _firebase.ObtenerProgreso(_userId);

        GlobalUser.currentLevel = level;

        lblLevel.Text = $"Nivel {level.ToString()}";
    }

    private async void OnImageTapped(object sender, EventArgs e)
    {
        if(GlobalUser.currentLevel != 1)
        {
            AvisoFrame.IsVisible = true;
        }
        else
        {
            await Navigation.PushAsync(new LetraA());
        }

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
    private async void leveldosclicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LeavelPage());
    }

    private async void repetirLevelTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LetraA());
    }
}