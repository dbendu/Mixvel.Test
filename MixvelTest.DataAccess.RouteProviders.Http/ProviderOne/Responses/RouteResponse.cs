namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Responses;

public class RouteResponse
{
    public Guid Id { get; set; }

    public RoutePointResponse Origin { get; set; } = null!;
    public RoutePointResponse Destination { get; set; } = null!;
    
    public decimal Price { get; set; }
    public DateTime TimeLimit { get; set; }
}

public class RoutePointResponse
{
    public required string City { get; set; }
    public DateTime DateTime { get; set; }
}
