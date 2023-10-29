namespace MixvelTest.BusinessLogic.Impl.Routes.Search.Mappers.Electors;

internal sealed class LongestRouteElector : BestRouteElector
{
    public LongestRouteElector()
        : base((lhs, rhs) => RouteDuration(lhs) > RouteDuration(rhs) ? lhs : rhs)
    { }
}