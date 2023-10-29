using MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo.Requests;
using MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo.Responses;
using Refit;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo;

internal interface IRouteProviderTwoHttpClient
{
    [Get("/api/v1/ping")]
    Task CheckAvailability(CancellationToken token);

    [Post("/api/v1/search")]
    Task<IReadOnlyCollection<RouteResponse>> Search(
        RoutesSearchRequest request,
        CancellationToken token
    );
}