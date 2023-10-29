namespace MixvelTest.BusinessLogic.Impl.Routes.Search.Mappers.Electors;

internal sealed class MostExpensiveRouteElector : BestRouteElector
{
    public MostExpensiveRouteElector()
        : base((lhs, rhs) => lhs.Price > rhs.Price ? lhs : rhs)
    { }
}