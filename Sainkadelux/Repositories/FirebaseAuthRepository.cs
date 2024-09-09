using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sainkadelux.Repositories
{
    public class FirebaseAuthRepository : IFirebaseAuthRepository
    {
        private readonly FirebaseConnect _firebaseConnect;

        public FirebaseAuthRepository()
        {
            _firebaseConnect = new FirebaseConnect();
        }

        public async Task<UserCredential> CreateUserAsync(string email, string password, string name)
        {
            return await _firebaseConnect.CrearUsuario(email, password, name);

        }

        public async Task SendPasswordResetEmailAsync(string email)
        {
            await _firebaseConnect.EnviarCorreoRestablecimientoContraseña(email);
        }

        public async Task<UserCredential> SignInAsync(string email, string password)
        {
            return await _firebaseConnect.CargarUsuario(email, password);
        }
    }
}
