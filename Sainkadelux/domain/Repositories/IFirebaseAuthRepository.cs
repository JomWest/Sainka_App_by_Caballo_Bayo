using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sainkadelux.domain.Repositories
{
    public interface IFirebaseAuthRepository
    {
        Task<UserCredential> SignInAsync(string email, string password);
        Task<UserCredential> CreateUserAsync(string email, string password, string name);
        Task SendPasswordResetEmailAsync(string email);
    }
}
