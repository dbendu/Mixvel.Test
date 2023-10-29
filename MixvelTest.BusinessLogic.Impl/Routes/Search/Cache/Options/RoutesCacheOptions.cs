using JetBrains.Annotations;

namespace MixvelTest.BusinessLogic.Impl.Routes.Search.Cache.Options;

internal class RoutesCacheOptions
{
    public TimeSpan MaxCacheTime { get; [UsedImplicitly] set; }
}