namespace MixvelText.BusinessLogic.Dependencies.Providers.Models;

public record SearchModel(
    string Origin,
    string Destination,
    DateTime OriginDateTime,
    DateTime? DestinationDateTime,
    decimal? MaxPrice,
    DateTime? MinTimeLimit
);
