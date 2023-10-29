using JetBrains.Annotations;
using Microsoft.Extensions.Caching.Memory;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.BusinessLogic.Impl.Routes.Search.Cache;

internal class SearchCache
{
    private readonly IMemoryCache _cache;

    public SearchCache(IMemoryCache cache)
    {
        _cache = cache;
    }

    public IReadOnlyCollection<RouteModel> Get(SearchModel searchModel)
    {
        var key = ComposeKey(searchModel);
        var routes = _cache.Get<IReadOnlyCollection<RouteModel>>(key);
        return routes ?? ArraySegment<RouteModel>.Empty;
    }

    public void Set(SearchModel searchModel, IReadOnlyCollection<RouteModel> searchResults)
    {
        var now = DateTimeOffset.UtcNow;
        var keepingPeriod = searchResults.Max(route => route.TimeLimit - now);
        
        var key = ComposeKey(searchModel);
        _cache.Set(key, searchResults, keepingPeriod);
    }

    private static RouteKey ComposeKey(SearchModel searchModel) => new()
    {
        Origin = searchModel.Origin,
        Destination = searchModel.Destination,
        Date = searchModel.OriginDateTime.Date
    };
    
    private struct RouteKey
    {
        public string Origin { [UsedImplicitly] get; set; }
        public string Destination { [UsedImplicitly] get; set; }
        public DateTime Date { [UsedImplicitly] get; set; }
    }
}