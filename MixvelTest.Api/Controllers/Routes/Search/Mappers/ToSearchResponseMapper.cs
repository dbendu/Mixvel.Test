using MixvelTest.Api.Controllers.Routes.Search.Responses;
using MixvelTest.BusinessLogic.Contract.Routes.Search.Models;

namespace MixvelTest.Api.Controllers.Routes.Search.Mappers;

public class ToSearchResponseMapper
{
    public SearchRoutesApiResponse Map(SearchResponse response)
    {
        return new SearchRoutesApiResponse(
            Routes: response.Routes
                .Select(route => new RouteApiResponse(
                    Id: route.Id,
                    Origin: route.Origin,
                    Destination: route.Destination,
                    OriginDateTime: route.OriginDateTime,
                    DestinationDateTime: route.DestinationDateTime,
                    Price: route.Price,
                    TimeLimit: route.TimeLimit))
                .ToArray(),
            MinPrice: response.MinPrice,
            MaxPrice: response.MaxPrice,
            MinMinutesRoute: response.MinMinutesRoute,
            MaxMinutesRoute: response.MaxMinutesRoute
        );
    }
}