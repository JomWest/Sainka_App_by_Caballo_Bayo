using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Sainkadelux.di;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Sainkadelux.ViewModels;
using Sainkadelux.data.Repositories;
using Sainkadelux.domain.Repositories;
using Sainkadelux.ui.ViewModels;

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
    }
}
