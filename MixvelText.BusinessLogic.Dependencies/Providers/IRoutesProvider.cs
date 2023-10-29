using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelText.BusinessLogic.Dependencies.Providers;

public interface IRoutesProvider
{
    Task<bool> Available(CancellationToken token);
    Task<IReadOnlyCollection<RouteModel>> Search(SearchModel search, CancellationToken token);
}