using DesafioBackendMiniQrApi.Application.Interfaces;
using DesafioBackendMiniQrApi.Application.Services;
using DesafioBackendMiniQrApi.CrossCutting.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace DesafioBackendMiniQrApi.CrossCutting;

public static class NativeDependecyInjector
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, AppSettings configuration)
    {
        services.AddScoped<IChargeService, ChargeService>();

        return services;
    }
}
