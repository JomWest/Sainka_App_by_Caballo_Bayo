using Microsoft.Maui.Layouts;
using Sainkadelux.ui.Niveles.Abecedario;

namespace Sainkadelux.ui.Niveles;

public partial class WorldPage : ContentPage
{
    Random random = new Random();
    const int numberOfStars = 7;
    public WorldPage()
	{
		InitializeComponent();
        CreateStars(numberOfStars);

    }

	private async void OnImageTappedVocalesWorld(object sender, EventArgs e)
	{
        Navigation.InsertPageBefore(new LeavelPage(), this);
        await Navigation.PopAsync();
    }

    private async void OnImageTappedABCWorld(object sender,EventArgs e)
    {
        Navigation.InsertPageBefore(new FirtsAbecedarioPage(), this);
        await Navigation.PopAsync();
    }
    private async void backtapped (object senderr,EventArgs e)
    {
        Navigation.InsertPageBefore(new MenuPage(), this);
        await Navigation.PopAsync();
    }

    private void CreateStars(int count)
    {
        for (int i = 0; i < count; i++)
        {
           
            var star = new Image
            {
                Source = "star.png", 
                WidthRequest = 50,
                HeightRequest = 50,
                Opacity = 1 
            };


            double x = random.NextDouble(); 
            double y = random.NextDouble();
            AbsoluteLayout.SetLayoutBounds(star, new Rect(x, y, -1, -1)); 
            AbsoluteLayout.SetLayoutFlags(star, AbsoluteLayoutFlags.PositionProportional);

            starContainer.Children.Add(star);


            AnimateStar(star);
        }
    }

    private void AnimateStar(Image star)
    {

        var blinkAnimation = new Animation(v => star.Opacity = v, 1, 0.4, Easing.Linear);
        blinkAnimation.Commit(star, "BlinkAnimation", length: 1000, repeat: () => true);

        
        Device.StartTimer(TimeSpan.FromSeconds(5), () =>
        {
            MoveStarToRandomPosition(star);
            return true; 
        });
    }

    private void MoveStarToRandomPosition(Image star)
    {
        
        double x = random.NextDouble(); 
        double y = random.NextDouble();

        AbsoluteLayout.SetLayoutBounds(star, new Rect(x, y, -1, -1)); 
    }
}