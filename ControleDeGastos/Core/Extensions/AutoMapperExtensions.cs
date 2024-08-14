using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Extensions;
public static class AutoMapperExtensions
{
    public static WebApplicationBuilder AddAutoMapper(this WebApplicationBuilder builder, params Assembly[] assemblies)
    {
        builder.Services.AddAutoMapper(opt =>
        {
            opt.ValueTransformers.Add<string>(value => (value != null ? value.Trim() : null)!);
        }, assemblies);

        return builder;
    }
}
