using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.BusinessLogic.Impl.Routes.Search.SearchStrategy;

internal interface ISearchStrategy
{
    Task<IReadOnlyCollection<RouteModel>> Search(SearchModel searchModel, CancellationToken token);
}
