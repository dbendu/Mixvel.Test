namespace MixvelTest.BusinessLogic.Impl.Routes.Search.Mappers.Electors;

internal sealed class CheapestRouteElector : BestRouteElector
{
    public CheapestRouteElector()
        : base((lhs, rhs) => lhs.Price < rhs.Price ? lhs : rhs)
    { }
}