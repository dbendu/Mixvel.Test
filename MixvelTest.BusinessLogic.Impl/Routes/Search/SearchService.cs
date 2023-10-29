using MixvelTest.BusinessLogic.Contract.Routes.Search;
using MixvelTest.BusinessLogic.Contract.Routes.Search.Models;
using MixvelTest.BusinessLogic.Impl.Routes.Search.Mappers;
using MixvelTest.BusinessLogic.Impl.Routes.Search.SearchStrategy;
using MixvelText.BusinessLogic.Dependencies.Providers;

namespace MixvelTest.BusinessLogic.Impl.Routes.Search;

internal class SearchService : ISearchService
{
    private readonly SearchStrategyFactory _searchStrategyFactory;
    private readonly IReadOnlyCollection<IRoutesProvider> _providers;
    private readonly ToSearchModelMapper _toModelMapper;
    private readonly ToSearchResponseMapper _toResponseMapper;

    public SearchService(
        SearchStrategyFactory searchStrategyFactory,
        IEnumerable<IRoutesProvider> providers,
        ToSearchModelMapper toModelMapper,
        ToSearchResponseMapper toResponseMapper)
    {
        _providers = providers.ToList();
        _toModelMapper = toModelMapper;
        _toResponseMapper = toResponseMapper;
        _searchStrategyFactory = searchStrategyFactory;
    }

    public async Task<SearchResponse> SearchAsync(
        SearchRequest request,
        CancellationToken cancellationToken)
    {
        var searchStrategy = _searchStrategyFactory.Create(request.Filters?.OnlyCached ?? false);
        
        var searchStrategyRequest = _toModelMapper.Map(request);
        var routes = await searchStrategy.Search(searchStrategyRequest, cancellationToken);
        
        return _toResponseMapper.Map(routes);
    }

    public async Task<bool> IsAvailableAsync(CancellationToken cancellationToken)
    {
        var tasks = _providers
            .Select(provider => provider.Available(cancellationToken))
            .ToArray();

        await Task.WhenAll(tasks);

        return tasks.Any(task => task.Result is true);
    }
}
