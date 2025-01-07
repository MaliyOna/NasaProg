using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NasaPet.DependencyInjection;

namespace NasaPet
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var connectionString = builder.Configuration["ConnectionStrings:Default"];
            builder.Services.AddServices(connectionString);
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
