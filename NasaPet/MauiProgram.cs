using Microsoft.Extensions.Logging;
using NasaPet.DependencyInjection;

namespace NasaPet
{
    public static class MauiProgram
    {
        private const string _connectionString = "Data Source=LocalDatabase.db";

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

            builder.Services.AddServices(_connectionString);
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
