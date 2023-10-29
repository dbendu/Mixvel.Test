using MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Responses;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Mappers;

internal class ResponseMapper
{
    public RouteModel Map(RouteResponse route)
    {
        return new RouteModel(
            Id: route.Id,
            Origin: route.Origin.City,
            OriginDateTime: route.Origin.DateTime,
            Destination: route.Destination.City,
            DestinationDateTime: route.Destination.DateTime,
            Price: route.Price,
            TimeLimit: route.TimeLimit
        );
    }
}