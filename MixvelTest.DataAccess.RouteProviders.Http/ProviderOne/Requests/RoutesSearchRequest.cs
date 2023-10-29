namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Requests;

internal record RoutesSearchRequest(
    PointDataRequest Origin,
    PointDataRequest Destination,
    decimal? MaxPrice
);

internal record PointDataRequest(
    string City,
    DateTime? Time
);
