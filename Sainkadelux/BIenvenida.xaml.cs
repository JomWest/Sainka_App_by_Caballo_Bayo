using Sainkadelux.di;
using Sainkadelux.ViewModels;

namespace Sainkadelux;

public partial class BIenvenida : ContentPage
{
    private const int TypingSpeed = 35;

    private LoginOptionPage _loginOptionPage;
    public BIenvenida()
	{
		InitializeComponent();
        _loginOptionPage = ServiceHelper.GetService<LoginOptionPage>();
	}
    private async void OnStartButtonClicked(object sender, EventArgs e)
    {

        AnimatedFrame.IsVisible = true;
        BotonInicio.IsVisible = false;

        await AnimatedFrame.TranslateTo(0, 0, 500, Easing.CubicInOut);
        AnimateTyping();


    }
    private async void AnimateTyping()
    {
        var originalText = "¡Bienvenido a Sainka! Comunícate sin barreras y conecta con el mundo a través del lenguaje de señas. ¡Estamos aquí para ayudarte a entender y ser entendido en cualquier momento y lugar!";
        Label welcomeLabel = WelcomeLabel;

        welcomeLabel.Text = string.Empty;
        foreach (var character in originalText)
        {
            welcomeLabel.Text += character;
            await Task.Delay(TypingSpeed);
        }
        Continuarbtn.IsVisible = true;
    }
    
    private async void OnMenuClicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(_loginOptionPage);


    }
}