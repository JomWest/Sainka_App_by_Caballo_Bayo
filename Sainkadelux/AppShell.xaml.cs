namespace Sainkadelux
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            CheckUserLoginStatus();
        }

        private void CheckUserLoginStatus()
        {

            var userId = Preferences.Get("UserId", null);

            if (!string.IsNullOrEmpty(userId))
            {
                CurrentItem = new MenuPage();
            }
            else
            {
                CurrentItem = new BIenvenida();
            }
        }
    }
}
