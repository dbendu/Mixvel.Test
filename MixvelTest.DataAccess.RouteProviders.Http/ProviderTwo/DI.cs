using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MixvelTest.DataAccess.RouteProviders.Http.Configs;
using MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo.Mappers;
using MixvelText.BusinessLogic.Dependencies.Providers;
using Refit;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo;

internal static class RouteProviderTwoInjection
{
    public static IServiceCollection RegisterRouteProviderTwo(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var clientConfig = configuration
            .GetSection("RouteProviderTwoClient")
            .Get<RouteProviderHttpClientConfig>()!;

        services
            .AddRefitClient<IRouteProviderTwoHttpClient>()
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri(clientConfig.BaseUrl);
                client.Timeout = clientConfig.Timeout;
            });

        services
            .AddScoped<ResponseMapper>()
            .AddScoped<ToRequestMapper>()
            .AddScoped<IRoutesProvider, RouteProviderTwo>();

        return services;
    }
}