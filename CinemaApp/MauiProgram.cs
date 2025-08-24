using CinemaApp.Core.Extensions;
using CinemaApp.Infrastructure.Extensions;
using Microsoft.Extensions.Logging;
using СinemaApp.MVVM.ViewModels;
using FFImageLoading.Maui;

namespace CinemaApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseFFImageLoading()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Arial.ttf", "Arial");
                });

            builder.Services.AddInfrastructure(builder.Configuration);
            builder.Services.AddCore(builder.Configuration);

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddTransient<DetailePage>();
            builder.Services.AddTransient<DetaileViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
