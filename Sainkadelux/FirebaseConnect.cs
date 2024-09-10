using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth.Providers;
using Firebase.Auth;
using Newtonsoft.Json;

namespace Sainkadelux
{
    class FirebaseConnect
    {
        private readonly HttpClient _httpClient;
        private readonly string _firebaseApiKey = "AIzaSyCQC9_kaY2FZzBPVfWa95XuR11lVPg0ZoQ";

        public FirebaseConnect()
        {
            _httpClient = new HttpClient();
        }

        public async Task EnviarCorreoRestablecimientoContraseña(string email)
        {
            var requestUri = $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={_firebaseApiKey}";
            var payload = new
            {
                requestType = "PASSWORD_RESET",
                email = email
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(requestUri, content);
            response.EnsureSuccessStatusCode(); 

            
        }
        public async Task<UserCredential> CrearUsuario(string email, string password, string nombre)
        {
            var cliente = ConectarFirebase();
            var userCredential = await cliente.CreateUserWithEmailAndPasswordAsync(email, password, nombre);

            // Obtener UID del usuario
            string userId = userCredential.User.Uid;

            // Crear una entrada en la base de datos para este usuario
            await CrearEntradaUsuarioEnBaseDeDatos(userId, nombre,email);

            return userCredential;
        }

        public async Task<UserCredential> CargarUsuario(string email, string password)
        {
            var cliente = ConectarFirebase();
            var userCredential = await cliente.SignInWithEmailAndPasswordAsync(email, password);
            var userId = userCredential.User.Uid;
            Preferences.Set("userId", userId);
            return userCredential;
        }

        public async Task CrearEntradaUsuarioEnBaseDeDatos(string userId, string name,string email)
        {
            var requestUri = $"https://sainkaapp-default-rtdb.firebaseio.com/users/{userId}.json";

            var payload = new
            {
                name = name,
                email = email,
                progreso = new { nivel = 1 } // Progreso inicial
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task GuardarProgreso(string userId, int nivel)
        {
            var requestUri = $"https://sainkaapp-default-rtdb.firebaseio.com/users/{userId}/progreso.json";

            var payload = new
            {
                nivel = nivel
            };

            var jsonPayload = JsonConvert.SerializeObject(payload);
            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(requestUri, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task<int> ObtenerProgreso(string userId)
        {
            var requestUri = $"https://sainkaapp-default-rtdb.firebaseio.com/users/{userId}/progreso.json";

            var response = await _httpClient.GetStringAsync(requestUri);
            var progreso = JsonConvert.DeserializeObject<dynamic>(response);

            return progreso?.nivel ?? 1; 
        }


        private FirebaseAuthClient ConectarFirebase()
        {
            var config = new FirebaseAuthConfig
            {
                ApiKey = _firebaseApiKey,
                AuthDomain = "sainkaapp.web.app",
                Providers = new FirebaseAuthProvider[]
                {

                    new GoogleProvider().AddScopes("email"),
                    new EmailProvider()
                },
            };

            var client = new FirebaseAuthClient(config);
            return client;
        }
    }
}
