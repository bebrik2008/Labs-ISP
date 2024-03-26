using Microsoft.Extensions.DependencyInjection; 
using Microsoft.Extensions.Logging;
using Lab4.Entities;
using Lab4.API;

namespace Lab4
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.Services.AddTransient<RateService>();
            builder.Services.AddHttpClient<IRateService>(opt =>
                opt.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates"));
            builder.Services.AddSingleton<MainPage>();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
