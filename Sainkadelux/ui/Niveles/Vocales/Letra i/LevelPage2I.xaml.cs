using Microsoft.Maui.Controls;

namespace Sainkadelux.ui.Niveles.Letra_i;

public partial class LevelPage2I : ContentPage
{
    private string selectedAnswer;
    public LevelPage2I()
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
        FrameI.BackgroundColor = Color.FromArgb("#2760DB");
        FrameE.BackgroundColor = Color.FromArgb("#2760DB");
        FrameA.BackgroundColor = Color.FromArgb("#2760DB");
    }
    private async void SiguienteRetoCliecked(object sender, EventArgs e)
    {
        Navigation.InsertPageBefore(new UltimoLevelPageI(), this);
        await Navigation.PopAsync();

    }

    private async void ReintenatrClicked(object sender, EventArgs e)
    {
        ResetFrameColors();
        ErrorFrame.IsVisible = false;
        OpcionesStack.IsVisible = true;

    }

    private async void NivelOneClicked(object sender, EventArgs e)
    {

        if (selectedAnswer == "I")
        {
            CheckFrame.IsVisible = true;
            Continuarbtn.IsVisible = false;
            OpcionesStack.IsVisible = false;
        }
        else
        {
            ErrorFrame.IsVisible = true;
            Continuarbtn.IsVisible = false;
            OpcionesStack.IsVisible = false;
        }
    }
}