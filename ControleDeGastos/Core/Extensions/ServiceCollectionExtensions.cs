using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterWhoImplements(
      this IServiceCollection service,
      Type interfaceType,
      Assembly[] assemblies,
      ServiceLifetime lifetime = ServiceLifetime.Scoped)
    {
        List<Type> list = ((IEnumerable<Assembly>)assemblies).SelectMany<Assembly, Type>((Func<Assembly, IEnumerable<Type>>)(x => (IEnumerable<Type>)x.GetTypes())).ToList<Type>();
        foreach (Type type in list.Where<Type>((Func<Type, bool>)(x => !x.IsClass && ((IEnumerable<Type>)x.GetInterfaces()).Contains<Type>(interfaceType))).Select<Type, Type>((Func<Type, Type>)(x => x)).ToList<Type>())
        {
            Type i = type;
            Type implementationType = list.Where<Type>((Func<Type, bool>)(x => x.IsClass && !x.IsAbstract && ((IEnumerable<Type>)x.GetInterfaces()).Contains<Type>(interfaceType) && ((IEnumerable<Type>)x.GetInterfaces()).Contains<Type>(i))).Select<Type, Type>((Func<Type, Type>)(x => x)).FirstOrDefault<Type>();
            if (!(implementationType == (Type)null))
            {
                switch (lifetime)
                {
                    case ServiceLifetime.Singleton:
                        ServiceCollectionServiceExtensions.AddSingleton(service, i, implementationType);
                        break;
                    case ServiceLifetime.Scoped:
                        service.AddScoped(i, implementationType);
                        break;
                    case ServiceLifetime.Transient:
                        service.AddTransient(i, implementationType);
                        break;
                }
            }
        }

        return service;
    }
}
