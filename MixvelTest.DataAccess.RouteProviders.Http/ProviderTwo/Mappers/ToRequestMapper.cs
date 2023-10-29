using MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo.Requests;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo.Mappers;

internal sealed class ToRequestMapper
{
    public RoutesSearchRequest Map(SearchModel searchModel)
    {
        return new RoutesSearchRequest(
            DepartureCity: searchModel.Origin,
            DestinationCity: searchModel.Destination,
            DepartureDateTime: searchModel.OriginDateTime,
            DestinationDateTime: searchModel.DestinationDateTime,
            MaxPrice: searchModel.MaxPrice,
            MinTimeLimit: searchModel.MinTimeLimit
        );
    }
}