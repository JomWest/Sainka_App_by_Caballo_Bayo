using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sainkadelux.di
{
    public class AppConfig
    {
        public string ApiBaseUrl { get; }
        public string FirebaseKey { get; }

        public AppConfig(string apiBaseUrl, string firebaseKey)
        {
            ApiBaseUrl = apiBaseUrl;
            FirebaseKey = firebaseKey;
        }
    }
}
