namespace MixvelTest.BusinessLogic.Impl.Routes.Search.Mappers.Electors;

internal sealed class FastestRouteElector : BestRouteElector
{
    public FastestRouteElector()
        : base((lhs, rhs) => RouteDuration(lhs) < RouteDuration(rhs) ? lhs : rhs)
    { }
}