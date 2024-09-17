using Core.MediatR.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Extensions;
public static class FluentValidatorExtensions
{
    public static IServiceCollection AddFluentValidator(this IServiceCollection services, params Assembly[] assemblies)
    {
        ValidatorOptions.Global.LanguageManager.Enabled = false;
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
        services.AddValidatorsFromAssemblies(assemblies, includeInternalTypes: true);

        return services;
    }
}
