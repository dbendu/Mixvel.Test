namespace MixvelTest.BusinessLogic.Contract.Routes.Search.Models;

public record SearchRequest(
    string Origin,
    string Destination,
    DateTime OriginDateTime,
    SearchFilters? Filters
);

public record SearchFilters(
    DateTime? DestinationDateTime,
    decimal? MaxPrice,
    DateTime? MinTimeLimit,
    bool? OnlyCached
);
