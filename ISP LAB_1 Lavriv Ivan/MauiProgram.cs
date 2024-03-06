using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;

namespace ISP_LAB_1_Lavriv_Ivan
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            // Регистрируем сервис IRateService и HttpClient в контейнере зависимостей
            builder.Services.AddTransient<IRateService, RateService>();
            builder.Services.AddTransient<HttpClient>(provider =>
            {
                var httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://www.nbrb.by/api/exrates/rates");
                return httpClient;
            });

            builder.Services.AddTransient<Currency_Converter>();

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
