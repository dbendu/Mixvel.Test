using MixvelTest.BusinessLogic.Impl.Routes.Search.SearchStrategy;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.BusinessLogic.Impl.Routes.Search.Cache;

internal class OnlyCachedSearchStrategy : ISearchStrategy
{
    private readonly SearchCache _cache;

    public OnlyCachedSearchStrategy(SearchCache cache)
    {
        _cache = cache;
    }

    public Task<IReadOnlyCollection<RouteModel>> Search(SearchModel searchModel, CancellationToken token)
    {
        _ = token;

        var cachedRoutes = _cache.Get(searchModel);
        return Task.FromResult(cachedRoutes);
    }
}