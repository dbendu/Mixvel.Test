using Microsoft.Extensions.Logging;
using MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo.Mappers;
using MixvelText.BusinessLogic.Dependencies.Providers;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.DataAccess.RouteProviders.Http.ProviderTwo;

internal class RouteProviderTwo : IRoutesProvider
{
    private const string Name = "Provider Two";

    private readonly ToRequestMapper _toRequestMapper;
    private readonly IRouteProviderTwoHttpClient _client;
    private readonly ResponseMapper _responseMapper;
    private readonly ILogger<RouteProviderTwo> _logger;

    public RouteProviderTwo(
        ToRequestMapper toRequestMapper,
        IRouteProviderTwoHttpClient client,
        ResponseMapper responseMapper,
        ILogger<RouteProviderTwo> logger)
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