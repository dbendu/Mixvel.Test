using MixvelTest.BusinessLogic.Contract.Routes.Search.Models;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.BusinessLogic.Impl.Routes.Search.Mappers;

internal class ToSearchModelMapper
{
    public SearchModel Map(SearchRequest search)
    {
        return new SearchModel(
            Origin: search.Origin,
            Destination: search.Destination,
            OriginDateTime: search.OriginDateTime,
            DestinationDateTime: search.Filters?.DestinationDateTime,
            MaxPrice: search.Filters?.MaxPrice,
            MinTimeLimit: search.Filters?.MinTimeLimit
        );
    }
}