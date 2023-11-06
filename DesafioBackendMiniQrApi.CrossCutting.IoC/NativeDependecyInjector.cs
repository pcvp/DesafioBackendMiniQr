using DesafioBackendMiniQrApi.Application.Interfaces;
using DesafioBackendMiniQrApi.Application.Services;
using DesafioBackendMiniQrApi.CrossCutting.Helpers;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioBackendMiniQrApi.CrossCutting;

public static class NativeDependecyInjector
{
    private static readonly string ASSEMBLY_NAME_DOMAIN = "DesafioBackendMiniQrApi.Domain";
    private static readonly string ASSEMBLY_NAME_APPLICATION = "DesafioBackendMiniQrApi.Application";
    private static readonly string ASSEMBLY_NAME_CROSS_CUTTING = "DesafioBackendMiniQrApi.CrossCutting";

    public static IServiceCollection RegisterServices(this IServiceCollection services, AppSettings configuration)
    {
        services.AddScoped<IChargeService, ChargeService>();

        services.AddAutoMapper(GetAssembliesToAutoMapper());
        return services;
    }

    public static IServiceCollection RegisterMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
        {
            foreach (var assembly in GetAssembliesToMediatR())
            {
                cfg.RegisterServicesFromAssembly(assembly);
            }
        });
        return services;
    }

    #region Métodos Privados 

    private static Assembly[] GetAssembliesToMediatR()
    {
        var assemblyNames = new[]
        {
            "DesafioBackendMiniQrApi.Domain",
            "DesafioBackendMiniQrApi.CrossCutting",
        };

        return assemblyNames.Select(name => Assembly.Load(name)).ToArray();
    }


    private static Assembly[] GetAssembliesToAutoMapper()
    {
        return new[]
        {
                AppDomain.CurrentDomain.Load(ASSEMBLY_NAME_DOMAIN),
                AppDomain.CurrentDomain.Load(ASSEMBLY_NAME_APPLICATION)
        };
    }
    #endregion
}
