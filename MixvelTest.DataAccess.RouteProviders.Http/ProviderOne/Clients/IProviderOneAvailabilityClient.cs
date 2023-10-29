using Refit;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Clients;

internal interface IProviderOneAvailabilityClient
{
    [Get("/api/v1/ping")]
    Task CheckAvailability(CancellationToken token);
}