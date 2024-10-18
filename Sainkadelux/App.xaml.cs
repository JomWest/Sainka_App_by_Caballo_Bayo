namespace Sainkadelux
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CheckUserLoginStatus();
        }

        private void CheckUserLoginStatus()
        {

            var userId = Preferences.Get("UserId", null);

            if (!string.IsNullOrEmpty(userId))
            {
                GlobalUser.UserId = userId;

                MainPage = new NavigationPage(new MenuPage());
            }
            else
            {
                MainPage = new NavigationPage(new BIenvenida());
            }
        }
    }
}
