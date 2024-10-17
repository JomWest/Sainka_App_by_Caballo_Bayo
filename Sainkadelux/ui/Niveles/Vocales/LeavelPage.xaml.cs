using Sainkadelux.data.Services;
using Sainkadelux.Niveles.Letra_a;
using Sainkadelux.ui.Niveles;
using Sainkadelux.ui.Niveles.Letra_e;
using Sainkadelux.ui.Niveles.Letra_i;
using Sainkadelux.ui.Niveles.Letra_o;
using Sainkadelux.ui.Niveles.Letra_u;

namespace Sainkadelux;

public partial class LeavelPage : ContentPage
{
    private string[] images = { "ab.png", "al.png" };
    private string[] imagesE = { "eb.png", "el.png" };
    private string[] imagesI = { "ib.png", "il.png" };
    private string[] imagesO = { "ob.png", "ol.png" };
    private string[] imagesU = { "ub.png", "ul.png" };
    private int currentImageIndex = 0;
    private string selectedAnswer;

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

        if (GlobalUser.currentLevel != 1)
        {
            var frame = sender as Image;
            selectedAnswer = (string)((TapGestureRecognizer)frame.GestureRecognizers[0]).CommandParameter;
            AvisoFrame.IsVisible = true;
        }
        else
        {
            Navigation.InsertPageBefore(new LetraA(), this);
            await Navigation.PopAsync();
        }

    }
    private async void OnImageETapped(object sender, EventArgs e)
    {
       
        if (GlobalUser.currentLevel != 2)
        {
            var frame = sender as Image;
            selectedAnswer = (string)((TapGestureRecognizer)frame.GestureRecognizers[0]).CommandParameter;
            AvisoFrame.IsVisible = true;
        }
        else
        {
            Navigation.InsertPageBefore(new LetraE(), this);
            await Navigation.PopAsync();
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
        if (selectedAnswer == "A")
        {
            Navigation.InsertPageBefore(new LetraE(), this);
            await Navigation.PopAsync();
        }
        else if (selectedAnswer == "E")
        {
            Navigation.InsertPageBefore(new LetraI(), this);
            await Navigation.PopAsync();
        }
        else if (selectedAnswer == "I")
        {
            Navigation.InsertPageBefore(new LetraO(), this);
            await Navigation.PopAsync();
        }
        else if (selectedAnswer == "O")
        {
            Navigation.InsertPageBefore(new LetraU(), this);
            await Navigation.PopAsync();
        }


    }

    private async void OnImageTappedoo(object sender, EventArgs e)
    {
      
        if (GlobalUser.currentLevel != 4)
        {
            var frame = sender as Image;
            selectedAnswer = (string)((TapGestureRecognizer)frame.GestureRecognizers[0]).CommandParameter;
            AvisoFrame.IsVisible = true;
        }
        else
        {
            Navigation.InsertPageBefore(new LetraO(), this);
            await Navigation.PopAsync();
        }
    }
    private async void OnImageTappedI(object sender, EventArgs e)
    {

        if (GlobalUser.currentLevel != 3)
        {
            var frame = sender as Image;
            selectedAnswer = (string)((TapGestureRecognizer)frame.GestureRecognizers[0]).CommandParameter;
            AvisoFrame.IsVisible = true;
        }
        else
        {
            Navigation.InsertPageBefore(new LetraI(), this);
            await Navigation.PopAsync();
        }
    }
    private async void OnImageTappedU(object sender, EventArgs e)
    {

        if (GlobalUser.currentLevel != 5)
        {
            var frame = sender as Image;
            selectedAnswer = (string)((TapGestureRecognizer)frame.GestureRecognizers[0]).CommandParameter;
            AvisoFrame.IsVisible = true;
            botonnivelnext.IsVisible = false;

        }
        else
        {
            Navigation.InsertPageBefore(new LetraU(), this);
            await Navigation.PopAsync();
        }
    }

    private async void BackButton(object sender,EventArgs e)
    {
        Navigation.InsertPageBefore(new WorldPage(), this);
        await Navigation.PopAsync();
    }


    private async void repetirLevelTapped(object sender, EventArgs e)
    {
        if (selectedAnswer == "A")
        {
            Navigation.InsertPageBefore(new LetraA(), this);
            await Navigation.PopAsync();
        }else if(selectedAnswer == "E")
        {
            Navigation.InsertPageBefore(new LetraE(), this);
            await Navigation.PopAsync();
        }
        else if(selectedAnswer == "I")
        {
            Navigation.InsertPageBefore(new LetraI(), this);
            await Navigation.PopAsync();
        }
        else if(selectedAnswer == "O")
        {
            Navigation.InsertPageBefore(new LetraO(), this);
            await Navigation.PopAsync();
        }
        else if (selectedAnswer == "U")
        {
            Navigation.InsertPageBefore(new LetraU(), this);
            await Navigation.PopAsync();
        }
    }
}