using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sainkadelux.domain.Repositories
{
    public interface INavigationService
    {
        Task NavigateToMenuPageAsync();

        Task NavigateToLoginOptionPageAsync();

        Task NavigateToRegisterPage();

    }


}
