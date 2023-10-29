using MixvelTest.BusinessLogic.Contract.Routes.Search.Models;
using MixvelTest.BusinessLogic.Impl.Routes.Search.Mappers.Electors;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.BusinessLogic.Impl.Routes.Search.Mappers;

internal class ToSearchResponseMapper
{
    private readonly BestRouteElector _cheapestRouteElector;
    private readonly BestRouteElector _mostExpensiveRouteElector;
    private readonly BestRouteElector _fastestRouteElector;
    private readonly BestRouteElector _longestRouteElector;
    private readonly List<BestRouteElector> _electors;

    public ToSearchResponseMapper(
        CheapestRouteElector cheapestRouteElector,
        MostExpensiveRouteElector mostExpensiveRouteElector,
        FastestRouteElector fastestRouteElector,
        LongestRouteElector longestRouteElector)
    {
        _cheapestRouteElector = cheapestRouteElector;
        _mostExpensiveRouteElector = mostExpensiveRouteElector;
        _fastestRouteElector = fastestRouteElector;
        _longestRouteElector = longestRouteElector;
        
        _electors = new List<BestRouteElector>
        {
            _cheapestRouteElector,
            _mostExpensiveRouteElector,
            _fastestRouteElector,
            _longestRouteElector
        };
    }
    
    public SearchResponse Map(IReadOnlyCollection<RouteModel> routes)
    {
        var responseRoutes = new Route[routes.Count];

        for (var i = 0; i < routes.Count; ++i)
        {
            var route = routes.ElementAt(i);

            _electors.ForEach(elector => elector.Index(route, i));

            responseRoutes[i] = new Route(
                Id: route.Id,
                Origin: route.Origin,
                Destination: route.Destination,
                OriginDateTime: route.OriginDateTime,
                DestinationDateTime: route.DestinationDateTime,
                Price: route.Price,
                TimeLimit: route.TimeLimit
            );
        }

        return new SearchResponse(
            Routes: responseRoutes,
            MinPrice: _cheapestRouteElector.BestRouteIndex,
            MaxPrice: _mostExpensiveRouteElector.BestRouteIndex,
            MinMinutesRoute: _fastestRouteElector.BestRouteIndex,
            MaxMinutesRoute: _longestRouteElector.BestRouteIndex
        );
    }
}
