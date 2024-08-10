using Application;
using Core;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ioc.DependencyInjection.Extensions;
public static class ServiceCollectionExtensions
{
    private static IServiceCollection AddCoreDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(
            Assembly.GetAssembly(typeof(IAmCoreAssembly)),
            Assembly.GetAssembly(typeof(IAmApplicationAssembly))
            );

        services.AddMediatR(Assembly.GetAssembly(typeof(IAmApplicationAssembly)));

        services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(IAmApplicationAssembly)));

        return services;
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddCoreDependencies();
    }
}
