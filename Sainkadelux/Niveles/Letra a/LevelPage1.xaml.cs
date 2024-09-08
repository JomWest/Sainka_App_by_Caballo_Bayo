using Microsoft.Maui.Controls;

namespace Sainkadelux.Niveles.Letra_a;

public partial class LevelPage1 : ContentPage
{
    // Declarar selectedAnswer como variable de instancia
    private string selectedAnswer;

    public LevelPage1()
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

    private async void ReintenatrClicked(object sender, EventArgs e)
    {
        ResetFrameColors();
        ErrorFrame.IsVisible = false;

    }

    private async void NivelOneClicked(object sender, EventArgs e)
    {
        // Ahora selectedAnswer ya es accesible
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
