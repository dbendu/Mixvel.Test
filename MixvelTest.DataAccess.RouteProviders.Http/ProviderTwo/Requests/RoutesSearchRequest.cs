namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo.Requests;

internal record RoutesSearchRequest(
    string DepartureCity,
    string DestinationCity,
    DateTime DepartureDateTime,
    DateTime? DestinationDateTime,
    decimal? MaxPrice,
    DateTime? MinTimeLimit
);
