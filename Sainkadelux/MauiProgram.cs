using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Sainkadelux.di;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Sainkadelux.ViewModels;
using Sainkadelux.data.Repositories;
using Sainkadelux.domain.Repositories;
using Sainkadelux.ui.ViewModels;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Sainkadelux
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                 .UseMauiCommunityToolkitCamera()
                 .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                    fonts.AddFont("Poppins-Light.ttf", "PoppinsLight");

                });

            builder.AddAppSettings();

            string sainkadeluxUrlBaseApi = builder.Configuration.GetValue<string>("BASE_URL_API");
            Console.WriteLine($"La URL base de la API es: {sainkadeluxUrlBaseApi}");

            string firebaseKey = builder.Configuration.GetValue<string>("FIREBASE_KEY");

            if (firebaseKey.Length != 0 && sainkadeluxUrlBaseApi.Length != 0)
            {
                builder.Services.AddSingleton(new AppConfig(sainkadeluxUrlBaseApi, firebaseKey));
            }


            builder.Services.AddSingleton<IFirebaseAuthRepository, FirebaseAuthRepository>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<RegisterViewModel>();
            builder.Services.AddSingleton<OlvidasteContraViewModel>();

            builder.Services.AddTransient<LoginOptionPage>();
            builder.Services.AddTransient<Func<LoginOptionPage>>(sp => () => sp.GetRequiredService<LoginOptionPage>());

            builder.Services.AddTransient<RegistrartePage>();
            builder.Services.AddTransient<Func<RegistrartePage>>(sp => () => sp.GetRequiredService<RegistrartePage>());

            builder.Services.AddTransient<OlidasteContraPage>();
            builder.Services.AddTransient<Func<OlidasteContraPage>>(sp => () => sp.GetRequiredService<OlidasteContraPage>());

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            ServiceHelper.Initialize(app.Services);

            return app;
        }

        private static void AddAppSettings(this MauiAppBuilder builder)
        {
            try
            {
                using Stream stream = Assembly.GetExecutingAssembly()
                   .GetManifestResourceStream("Sainkadelux.appsettings.json");

                if (stream != null)
                {
                    IConfiguration config = new ConfigurationBuilder()
                        .AddJsonStream(stream).Build();
                    builder.Configuration.AddConfiguration(config);
                }
                else
                {
                    Console.WriteLine("No se encontró el archivo appsettings.json en los recursos incrustados.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar appsettings.json: {ex.Message}");
            }
        }

    }
}
