using MixvelTest.BusinessLogic.Impl.Routes.Search.Cache;

namespace MixvelTest.BusinessLogic.Impl.Routes.Search.SearchStrategy;

internal class SearchStrategyFactory
{
    private readonly ISearchStrategy _onlyCached;
    private readonly ISearchStrategy _providersSearch;

    public SearchStrategyFactory(
        OnlyCachedSearchStrategy onlyCached,
        ByProvidersSearchStrategy providersSearch)
    {
        _onlyCached = onlyCached;
        _providersSearch = providersSearch;
    }

    public ISearchStrategy Create(bool cachedOnly)
    {
        return cachedOnly switch
        {
            true => _onlyCached,
            false => _providersSearch
        };
    }
}
