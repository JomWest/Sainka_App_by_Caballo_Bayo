using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Sainkadelux.di;
using Sainkadelux.Repositories;
using Sainkadelux.ViewModels;

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
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                    fonts.AddFont("Poppins-Light.ttf", "PoppinsLight");

                });

            builder.Services.AddSingleton<IFirebaseAuthRepository, FirebaseAuthRepository>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            builder.Services.AddSingleton<LoginViewModel>();
            builder.Services.AddSingleton<RegisterViewModel>();

            builder.Services.AddTransient<LoginOptionPage>();
            builder.Services.AddTransient<Func<LoginOptionPage>>(sp => () => sp.GetRequiredService<LoginOptionPage>());

            builder.Services.AddTransient<RegistrartePage>();
            builder.Services.AddTransient<Func<RegistrartePage>>(sp => () => sp.GetRequiredService<RegistrartePage>());


#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            ServiceHelper.Initialize(app.Services);

            return app;
        }
    }
}
