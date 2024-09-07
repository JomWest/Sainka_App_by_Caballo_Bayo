using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sainkadelux.Repositories
{
    public class NavigationService : INavigationService
    {
        public async Task NavigateToMenuPageAsync()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new MenuPage());

        }
    }
}
