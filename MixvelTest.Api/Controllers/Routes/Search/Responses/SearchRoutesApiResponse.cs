using JetBrains.Annotations;

namespace MixvelTest.Api.Controllers.Routes.Search.Responses;

[PublicAPI]
public record SearchRoutesApiResponse(
    IReadOnlyCollection<RouteApiResponse> Routes,
    decimal MinPrice,
    decimal MaxPrice,
    int MinMinutesRoute,
    int MaxMinutesRoute
);

[PublicAPI]
public record RouteApiResponse(
    Guid Id,
    string Origin,
    string Destination,
    DateTime OriginDateTime,
    DateTime DestinationDateTime,
    decimal Price,
    DateTime TimeLimit
);
