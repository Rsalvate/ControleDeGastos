using Core.Extensions;
using Core.Repositories;
using Core.UoW;
using Data.Contexts;
using Data.Settings;
using Data.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IOC.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, params Assembly[] assemblies)
    {
        services.RegisterWhoImplements(typeof(IRepository), assemblies);

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddMediatR(assemblies);
        services.AddCoreAutoMapper(assemblies);
        services.AddFluentValidator(assemblies);

        return services;
    }

    public static IServiceCollection AddEfCore(this IServiceCollection services, Func<EfCoreSettings> action)
    {
        var settings = action();
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(settings.ControleContasConnectionString));

        return services;
    }
}
