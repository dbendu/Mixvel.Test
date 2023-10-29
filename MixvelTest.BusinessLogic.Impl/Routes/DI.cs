using Microsoft.Extensions.DependencyInjection;
using MixvelTest.BusinessLogic.Contract.Routes.Search;
using MixvelTest.BusinessLogic.Impl.Routes.Cache;
using MixvelTest.BusinessLogic.Impl.Routes.Search;
using MixvelTest.BusinessLogic.Impl.Routes.Search.Cache;
using MixvelTest.BusinessLogic.Impl.Routes.Search.Cache.Options;
using MixvelTest.BusinessLogic.Impl.Routes.Search.Mappers;
using MixvelTest.BusinessLogic.Impl.Routes.Search.Mappers.Electors;
using MixvelTest.BusinessLogic.Impl.Routes.Search.SearchStrategy;

namespace MixvelTest.BusinessLogic.Impl.Routes;

internal static class RoutesRegistration
{
    public static IServiceCollection AddRoutes(this IServiceCollection services)
    {
        services
            .AddOptions<RoutesCacheOptions>()
            .BindConfiguration("RoutesCacheOptions");

        return services
            .AddTransient<ISearchService, SearchService>()
            .Decorate<ISearchService, CachingSearchService>()
            .AddTransient<ToSearchModelMapper>()
            .AddTransient<SearchStrategyFactory>()
            .AddTransient<OnlyCachedSearchStrategy>()
            .AddTransient<ByProvidersSearchStrategy>()
            .AddTransient<SearchCache>()
            .AddTransient<ToSearchResponseMapper>()
            .AddTransient<LongestRouteElector>()
            .AddTransient<CheapestRouteElector>()
            .AddTransient<FastestRouteElector>()
            .AddTransient<MostExpensiveRouteElector>();
    }
}