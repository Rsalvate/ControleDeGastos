using Data.Contexts;
using Data.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IOC.Extensions;
public static class InfraServiceCollectionExtension
{
    public static IServiceCollection AddEfCore(this IServiceCollection services, Func<EfCoreSettings> action)
    {
        var settings = action();
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(settings.ControleContasConnectionString));
        
        return services;
    }
}
