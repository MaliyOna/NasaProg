using NasaPet.DAL.DependencyInjection;

namespace NasaPet.DependencyInjection;

public static class DI
{
    public static void AddServices(this IServiceCollection services, string connectionString)
    {
        services.AddDALServices(connectionString);
    }
}
