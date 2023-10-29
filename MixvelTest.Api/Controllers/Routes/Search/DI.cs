using MixvelTest.Api.Controllers.Routes.Search.Mappers;

namespace MixvelTest.Api.Controllers.Routes.Search;

internal static class RoutesSearchControllerRegistration
{
    public static IServiceCollection AddRoutesSearchController(this IServiceCollection services)
    {
        return services
            .AddTransient<ToSearchRequestMapper>()
            .AddTransient<ToSearchResponseMapper>();
    }
}