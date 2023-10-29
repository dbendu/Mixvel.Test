using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using MixvelTest.BusinessLogic.Contract.Routes.Search.Models;
using MixvelTest.BusinessLogic.Impl.Context;
using MixvelTest.BusinessLogic.Impl.Routes.Search.Cache.Options;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.BusinessLogic.Impl.Routes.Cache;

internal class RoutesCache
{
    private readonly IMemoryCache _cache;
    private readonly IOptions<RoutesCacheOptions> _cacheOptions;
    private readonly RequestContext _context; 

    public RoutesCache(
        IMemoryCache cache,
        IOptions<RoutesCacheOptions> cacheOptions,
        RequestContext context)
    {
        _cache = cache;
        _cacheOptions = cacheOptions;
        _context = context;
    }

    public void Put(IEnumerable<Route> routes)
    {
        foreach (var route in routes)
        {
            _cache.Set(route.Id, route, CalculateExpirationTime(route.TimeLimit));
        }
    }

    private TimeSpan CalculateExpirationTime(DateTime routeValidUntil)
    {
        var routeExpiresIn = routeValidUntil - _context.Now;
        var maxStorageTime = _cacheOptions.Value.MaxCacheTime;

        return routeExpiresIn < maxStorageTime
            ? routeExpiresIn
            : maxStorageTime;
    }

    public RouteModel? Get(Guid routeId) => _cache.Get<RouteModel>(routeId);
}