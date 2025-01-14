using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace NasaPet.DAL.DependencyInjection;

public static class DI
{
    public static void AddDALServices(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString),
            ServiceLifetime.Scoped);
    }
}
