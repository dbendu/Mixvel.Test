using MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo.Responses;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo.Mappers;

internal class ResponseMapper
{
    public RouteModel Map(RouteResponse route)
    {
        return new RouteModel(
            Id: route.Id,
            Origin: route.DepartureCity,
            OriginDateTime: route.DepartureDateTime,
            Destination: route.DestinationCity,
            DestinationDateTime: route.DestinationDateTime,
            Price: route.Price,
            TimeLimit: route.TimeLimit
        );
    }
}