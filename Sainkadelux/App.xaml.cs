namespace Sainkadelux
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new BIenvenida());
        }
    }
}
