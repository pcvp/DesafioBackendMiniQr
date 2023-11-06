using System.Reflection;
using DesafioBackendMiniQrApi.Application.Interfaces;
using DesafioBackendMiniQrApi.Application.Services;
using DesafioBackendMiniQrApi.CrossCutting.ErrorNotification;
using DesafioBackendMiniQrApi.CrossCutting.Helpers;
using DesafioBackendMiniQrApi.CrossCutting.Interfaces;
using DesafioBackendMiniQrApi.Data.Context;
using DesafioBackendMiniQrApi.Data.Repositories;
using DesafioBackendMiniQrApi.Data.Uow;
using DesafioBackendMiniQrApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioBackendMiniQrApi.CrossCutting.IoC;

public static class NativeDependecyInjector
{
    private const string AssemblyNameDomain = "DesafioBackendMiniQrApi.Domain";
    private const string AssemblyNameApplication = "DesafioBackendMiniQrApi.Application";
    private const string AssemblyNameCrossCutting = "DesafioBackendMiniQrApi.CrossCutting";

    public static IServiceCollection RegisterServices(this IServiceCollection services, AppSettings configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IErrorNotificationResult, ErrorNotificationResult>();

        services.AddDbContextPool<DataBaseContext>((services, optionsBuilder) =>
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(configuration?.ConnectionStrings?.DbContext ?? string.Empty);
        });

        services.AddScoped<IChargeService, ChargeService>();
        services.AddScoped<IChargeRepository, ChargeRepository>();

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
            AssemblyNameDomain,
            AssemblyNameCrossCutting
        };

        return assemblyNames.Select(name => Assembly.Load(name)).ToArray();
    }


    private static Assembly[] GetAssembliesToAutoMapper()
    {
        return new[]
        {
                AppDomain.CurrentDomain.Load(AssemblyNameDomain),
                AppDomain.CurrentDomain.Load(AssemblyNameApplication)
        };
    }
    #endregion
}
