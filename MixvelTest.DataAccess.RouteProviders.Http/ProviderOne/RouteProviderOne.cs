using Microsoft.Extensions.Logging;
using MixvelTest.DataAccess.RouteProviders.Http.ProviderOne.Mappers;
using MixvelText.BusinessLogic.Dependencies.Providers;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderOne;

internal class RouteProviderOne : IRoutesProvider
{
    private const string Name = "Provider One";

    private readonly ToRequestMapper _toRequestMapper;
    private readonly IRouteProviderOneHttpClient _client;
    private readonly ResponseMapper _responseMapper;
    private readonly ILogger<RouteProviderOne> _logger;

    public RouteProviderOne(
        ToRequestMapper toRequestMapper,
        IRouteProviderOneHttpClient client,
        ResponseMapper responseMapper,
        ILogger<RouteProviderOne> logger)
    {
        _toRequestMapper = toRequestMapper;
        _client = client;
        _responseMapper = responseMapper;
        _logger = logger;
    }

    public async Task<bool> Available(CancellationToken token)
    {
        try
        {
            await _client.CheckAvailability(token);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogInformation(ex, "Provider {ProviderName} is unavailable", Name);
            return false;
        }
    }

    public async Task<IReadOnlyCollection<RouteModel>> Search(
        SearchModel search,
        CancellationToken token)
    {
        var request = _toRequestMapper.Map(search);

        try
        {
            var response = await _client.Search(request, token);
            return response.Select(_responseMapper.Map).ToArray();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occured while fetching routes from {ProviderName}", Name);
            return ArraySegment<RouteModel>.Empty;
        }
    }
}