using Sainkadelux.di;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sainkadelux.Repositories
{
    public class NavigationService(Func<LoginOptionPage> loginOptionPageFactory, Func<RegistrartePage> registrartePageFactorty) : INavigationService
    {

        public async Task NavigateToLoginOptionPageAsync()
        {
            var loginOptionPage = loginOptionPageFactory();
            await Application.Current.MainPage.Navigation.PushAsync(loginOptionPage);

        }

        public async Task NavigateToMenuPageAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MenuPage());

        }

        public async Task NavigateToRegisterPage()
        {
            var registerPage = registrartePageFactorty();
            await Application.Current.MainPage.Navigation.PushAsync(registerPage);
        }
    }
}
