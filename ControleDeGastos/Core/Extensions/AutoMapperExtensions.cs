using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Extensions;
public static class AutoMapperExtensions
{
    public static IServiceCollection AddCoreAutoMapper(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.AddAutoMapper(opt =>
         {
             opt.ValueTransformers.Add<string>(value => (value != null ? value.Trim() : null)!);
         }, assemblies);

        return services;
    }
}
