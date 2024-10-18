namespace Sainkadelux.ui.Niveles.Abecedario.Letra_ch;

public partial class LevelPage2CH : ContentPage
{

    private string selectedAnswer;

    public LevelPage2CH()
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
        FrameT.BackgroundColor = Color.FromArgb("#2760DB");
        FrameCH.BackgroundColor = Color.FromArgb("#2760DB");
        FrameP.BackgroundColor = Color.FromArgb("#2760DB");
    }
    private async void SiguienteRetoCliecked(object sender, EventArgs e)
    {
        Navigation.InsertPageBefore(new UltimoPageCH(), this);
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

        if (selectedAnswer == "CH")
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