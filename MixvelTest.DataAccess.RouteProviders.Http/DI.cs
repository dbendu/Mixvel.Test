using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MixvelTest.DataAccess.RouteProviders.Http.ProviderOne;
using MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo;

namespace MixvelTest.DataAccess.RouteProviders.Http;

internal static class HttpRouteProvidersRegistration
{
    public static IServiceCollection AddHttpRouteProviders(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        return services
            .RegisterRouteProviderOne(configuration)
            .RegisterRouteProviderTwo(configuration);
    }
}