using MixvelTest.Api.Controllers.Routes.Search.Requests;
using MixvelTest.BusinessLogic.Contract.Routes.Search.Models;

namespace MixvelTest.Api.Controllers.Routes.Search.Mappers;

public class ToSearchRequestMapper
{
    public SearchRequest Map(SearchRoutesApiRequest request)
    {
        return new SearchRequest(
            Origin: request.Origin,
            Destination: request.Destination,
            OriginDateTime: request.OriginDateTime,
            Filters: new SearchFilters(
                DestinationDateTime: request.Filters?.DestinationDateTime,
                MaxPrice: request.Filters?.MaxPrice,
                MinTimeLimit: request.Filters?.MinTimeLimit,
                OnlyCached: request.Filters?.OnlyCached
            )
        );
    }
}