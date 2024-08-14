using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IOC.Extensions;
public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatr(assemblies);

        return services;
    }

    private static void AddMediatr(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assemblies));
    }
}
