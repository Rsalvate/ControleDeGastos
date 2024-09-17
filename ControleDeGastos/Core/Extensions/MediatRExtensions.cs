using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Extensions;
public static class MediatRExtensions
{
    public static IServiceCollection AddMediatR(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddMediatR(crf => crf.RegisterServicesFromAssemblies(assemblies));
        return services;
    }
}
