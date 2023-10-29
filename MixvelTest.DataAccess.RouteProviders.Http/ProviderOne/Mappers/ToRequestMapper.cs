using MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Requests;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Mappers;

internal sealed class ToRequestMapper
{
    public RoutesSearchRequest Map(SearchModel searchModel)
    {
        return new RoutesSearchRequest(
            Origin: new PointDataRequest(
                City: searchModel.Origin,
                Time: searchModel.OriginDateTime
            ),
            Destination: new PointDataRequest(
                City: searchModel.Destination,
                Time: searchModel.DestinationDateTime
            ),
            MaxPrice: searchModel.MaxPrice
        );
    }
}