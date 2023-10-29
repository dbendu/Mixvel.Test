using MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Requests;
using MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Responses;
using Refit;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderOne;

internal interface IRouteProviderOneHttpClient
{
    [Get("/api/v1/ping")]
    Task CheckAvailability(CancellationToken token);

    [Post("/api/v1/search")]
    Task<IReadOnlyCollection<RouteResponse>> Search(
        RoutesSearchRequest request,
        CancellationToken token
    );
}