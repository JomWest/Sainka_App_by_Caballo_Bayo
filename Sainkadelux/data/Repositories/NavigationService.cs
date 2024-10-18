using Sainkadelux.di;
using Sainkadelux.domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sainkadelux.data.Repositories
{
    public class NavigationService(Func<LoginOptionPage> loginOptionPageFactory, Func<RegistrartePage> registrartePageFactorty, Func<OlidasteContraPage> olvidasteContraPage) : INavigationService
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

        public async Task NavigateToResetEmail()
        {
            var resetPasswordPage = olvidasteContraPage();
            await Application.Current.MainPage.Navigation.PushAsync(resetPasswordPage);
        }

        public async Task PopUpNavigation()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
