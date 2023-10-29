namespace MixvelText.BusinessLogic.Dependencies.Providers.Models;

public record RouteModel(
    Guid Id,
    string Origin,
    string Destination,
    DateTime OriginDateTime,
    DateTime DestinationDateTime,
    decimal Price,
    DateTime TimeLimit
);
