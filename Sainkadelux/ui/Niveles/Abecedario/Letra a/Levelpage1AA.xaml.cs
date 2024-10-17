using Microsoft.Maui.Controls;

namespace Sainkadelux.ui.Niveles.Abecedario.Letra_a;

public partial class Levelpage1AA : ContentPage
{
    private string selectedAnswer;
    public Levelpage1AA()
	{
		InitializeComponent();
	}
    private void OnAnswerTapped(object sender, EventArgs e)
    {
        ResetFrameColors();
        var frame = sender as Frame;
        selectedAnswer = (string)((TapGestureRecognizer)frame.GestureRecognizers[0]).CommandParameter;
        frame.BackgroundColor = Color.FromArgb("#00F1AF");
        Continuarbtn.IsVisible = true;
    }

    private void ResetFrameColors()
    {
        FrameA.BackgroundColor = Colors.LightGray;
        FrameE.BackgroundColor = Colors.LightGray;
        FrameI.BackgroundColor = Colors.LightGray;
    }
    private async void SiguienteRetoCliecked(object sender, EventArgs e)
    {
        Navigation.InsertPageBefore(new LevelPage2AA(), this);
        await Navigation.PopAsync();

    }
    private async void ReintenatrClicked(object sender, EventArgs e)
    {
        ResetFrameColors();
        ErrorFrame.IsVisible = false;

    }

    private async void NivelOneClicked(object sender, EventArgs e)
    {

        if (selectedAnswer == "A")
        {
            CheckFrame.IsVisible = true;
            Continuarbtn.IsVisible = false;
        }
        else
        {
            ErrorFrame.IsVisible = true;
            Continuarbtn.IsVisible = false;
        }
    }
}