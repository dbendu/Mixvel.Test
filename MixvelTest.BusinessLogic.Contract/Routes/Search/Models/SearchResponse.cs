namespace MixvelTest.BusinessLogic.Contract.Routes.Search.Models;

public record SearchResponse(
    IReadOnlyCollection<Route> Routes,
    decimal MinPrice,
    decimal MaxPrice,
    int MinMinutesRoute,
    int MaxMinutesRoute
);

public record Route(
    Guid Id,
    string Origin,
    string Destination,
    DateTime OriginDateTime,
    DateTime DestinationDateTime,
    decimal Price,
    DateTime TimeLimit
);
