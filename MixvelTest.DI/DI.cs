using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MixvelTest.BusinessLogic.Impl;
using MixvelTest.DataAccess.RouteProviders.Http;

namespace MixvelTest.DI;

public static class DependencyInjection
{
    public static IServiceCollection AddServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .AddHttpRouteProviders(configuration)
            .AddBusinessLogic()
            .AddCache();
    }

    private static IServiceCollection AddCache(this IServiceCollection services)
    {
        return services.AddMemoryCache(setup =>
        {
            setup.ExpirationScanFrequency = TimeSpan.FromSeconds(15);
        });
    }
}