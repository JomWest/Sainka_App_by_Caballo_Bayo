namespace Sainkadelux.ui.Niveles.Abecedario.Letra_D;

public partial class LevelPage1D : ContentPage
{

    private string selectedAnswer;

    public LevelPage1D()
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
        FrameH.BackgroundColor = Colors.LightGray;
        FrameT.BackgroundColor = Colors.LightGray;
        FrameD.BackgroundColor = Colors.LightGray;
    }
    private async void SiguienteRetoCliecked(object sender, EventArgs e)
    {
        Navigation.InsertPageBefore(new LevelPage2D(), this);
        await Navigation.PopAsync();

    }
    private async void ReintenatrClicked(object sender, EventArgs e)
    {
        ResetFrameColors();
        ErrorFrame.IsVisible = false;

    }

    private async void NivelOneClicked(object sender, EventArgs e)
    {

        if (selectedAnswer == "D")
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