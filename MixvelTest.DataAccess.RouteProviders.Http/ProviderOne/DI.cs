using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MixvelTest.DataAccess.RouteProviders.Http.Configs;
using MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Mappers;
using MixvelText.BusinessLogic.Dependencies.Providers;
using Refit;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderOne;

internal static class RouteProviderOneInjection
{
    public static IServiceCollection RegisterRouteProviderOne(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var clientConfig = configuration
            .GetSection("RouteProviderOneClient")
            .Get<RouteProviderHttpClientConfig>()!;

        services
            .AddRefitClient<IRouteProviderOneHttpClient>()
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(clientConfig.BaseUrl);
                client.Timeout = clientConfig.Timeout;
            });

        services
            .AddScoped<ResponseMapper>()
            .AddScoped<ToRequestMapper>()
            .AddScoped<IRoutesProvider, RouteProviderOne>();

        return services;
    }
}