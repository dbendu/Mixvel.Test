using JetBrains.Annotations;

namespace MixvelTest.Api.Controllers.Routes.Search.Requests;

[PublicAPI]
public record SearchRoutesApiRequest(
    string Origin,
    string Destination,
    DateTime OriginDateTime,
    SearchFiltersApiRequest? Filters
);

[PublicAPI]
public record SearchFiltersApiRequest(
    DateTime? DestinationDateTime,
    decimal? MaxPrice,
    DateTime? MinTimeLimit,
    bool? OnlyCached
);