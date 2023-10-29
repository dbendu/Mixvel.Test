using MixvelTest.BusinessLogic.Contract.Routes.Search.Models;

namespace MixvelTest.BusinessLogic.Contract.Routes.Search;

public interface ISearchService
{
    Task<SearchResponse> SearchAsync(SearchRequest request, CancellationToken cancellationToken);
    Task<bool> IsAvailableAsync(CancellationToken cancellationToken);
}