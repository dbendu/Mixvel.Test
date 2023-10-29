using MixvelTest.BusinessLogic.Contract.Routes.Search;
using MixvelTest.BusinessLogic.Contract.Routes.Search.Models;

namespace MixvelTest.BusinessLogic.Impl.Routes.Cache;

internal class CachingSearchService : ISearchService
{
    private readonly ISearchService _service;
    private readonly RoutesCache _cache;

    public CachingSearchService(
        ISearchService service,
        RoutesCache cache)
    {
        _service = service;
        _cache = cache;
    }

    public async Task<SearchResponse> SearchAsync(
        SearchRequest request,
        CancellationToken cancellationToken)
    {
        var searchResult = await _service.SearchAsync(request, cancellationToken);
        _cache.Put(searchResult.Routes);
        return searchResult;
    }

    public Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
    {
        return _service.IsAvailableAsync(cancellationToken);
    }
}