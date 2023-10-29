using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.BusinessLogic.Impl.Routes.Search.Mappers.Electors;

internal abstract class BestRouteElector
{
    private readonly Func<RouteModel, RouteModel, RouteModel> _betterRouteElector;
    private RouteModel? _bestRoute;
    public int BestRouteIndex { get; private set; } = -1;

    public BestRouteElector(Func<RouteModel, RouteModel, RouteModel> betterRouteElector)
    {
        _betterRouteElector = betterRouteElector;
    }

    public void Index(RouteModel route, int routeIndex)
    {
        if (_bestRoute is null || _betterRouteElector(route, _bestRoute) == route)
        {
            _bestRoute = route;
            BestRouteIndex = routeIndex;
        }
    }
    
    protected static TimeSpan RouteDuration(RouteModel route) => route.DestinationDateTime - route.OriginDateTime;
}