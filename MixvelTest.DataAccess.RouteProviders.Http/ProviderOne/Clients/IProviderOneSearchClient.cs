using MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Requests;
using MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Responses;
using Refit;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Clients;

internal interface IProviderOneSearchClient
{
    [Post("/api/v1/search")]
    Task<IReadOnlyCollection<RouteResponse>> Search(
        RoutesSearchRequest request,
        CancellationToken token
    );
}