using Microsoft.Maui.Controls;

namespace Sainkadelux.ui.Niveles.Abecedario.Letra_b;

public partial class LevelPage1b : ContentPage
{
    private string selectedAnswer;

    public LevelPage1b()
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
        FrameJ.BackgroundColor = Colors.LightGray;
        FrameB.BackgroundColor = Colors.LightGray;
        FrameC.BackgroundColor = Colors.LightGray;
    }
    private async void SiguienteRetoCliecked(object sender, EventArgs e)
    {
        Navigation.InsertPageBefore(new LevelPage2b(), this);
        await Navigation.PopAsync();

    }
    private async void ReintenatrClicked(object sender, EventArgs e)
    {
        ResetFrameColors();
        ErrorFrame.IsVisible = false;

    }

    private async void NivelOneClicked(object sender, EventArgs e)
    {

        if (selectedAnswer == "B")
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