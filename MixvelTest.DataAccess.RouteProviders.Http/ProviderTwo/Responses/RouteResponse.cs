namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo.Responses;

public class RouteResponse
{
    public Guid Id { get; set; }
    
    public required string DepartureCity { get; set; }
    public required string DestinationCity { get; set; }

    public DateTime DepartureDateTime { get; set; }
    public DateTime DestinationDateTime { get; set; }

    public decimal Price { get; set; }
    public DateTime TimeLimit { get; set; }
}