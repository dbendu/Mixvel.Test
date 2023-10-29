using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MixvelTest.Api.Controllers.Routes.Search.Mappers;
using MixvelTest.Api.Controllers.Routes.Search.Requests;
using MixvelTest.Api.Controllers.Routes.Search.Responses;
using MixvelTest.BusinessLogic.Contract.Routes.Search;

namespace MixvelTest.Api.Controllers.Routes.Search;

public class RoutesSearchController : ControllerBase
{
    private readonly ToSearchRequestMapper _requestMapper;
    private readonly ISearchService _searchService;
    private readonly ToSearchResponseMapper _responseMapper;

    public RoutesSearchController(
        ToSearchRequestMapper requestMapper,
        ISearchService searchService,
        ToSearchResponseMapper responseMapper)
    {
        _requestMapper = requestMapper;
        _searchService = searchService;
        _responseMapper = responseMapper;
    }

    [HttpPost("api/mixvel/routes/search")]
    [ProducesResponseType(typeof(SearchRoutesApiResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchRoutes(
        [FromBody] [Required] SearchRoutesApiRequest request,
        CancellationToken token)
    {
        var searchResult = await _searchService.SearchAsync(
            _requestMapper.Map(request),
            token
        );

        var payload = _responseMapper.Map(searchResult);
        return Ok(payload);
    }

    [HttpGet("api/mixvel/routes/search/available")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public async Task<IActionResult> SearchRoutesApiAvailability(CancellationToken token)
    {
        var available = await _searchService.IsAvailableAsync(token);
        return Ok(available);
    }
}