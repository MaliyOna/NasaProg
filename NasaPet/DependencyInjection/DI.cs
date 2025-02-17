using NasaPet.APIs;
using NasaPet.Models;

namespace NasaPet.DependencyInjection;

public static class DI
{
    public static void AddServices(this IServiceCollection services, string connectionString)
    {
        services.AddHttpClient();

        services.AddHttpClient("NasaClient", client =>
        {
            client.BaseAddress = new Uri("https://eonet.gsfc.nasa.gov/api/v2.1");
        });
        services.AddScoped<INasaHttpClient<NewsRootModel>, NasaHttpClient<NewsRootModel>>();
        //services.AddDALServices(connectionString);
    }
}
