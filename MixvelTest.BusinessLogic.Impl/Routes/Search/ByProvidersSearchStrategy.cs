using Microsoft.Extensions.Logging;
using MixvelTest.BusinessLogic.Impl.Routes.Search.SearchStrategy;
using MixvelText.BusinessLogic.Dependencies.Providers;
using MixvelText.BusinessLogic.Dependencies.Providers.Models;

namespace MixvelTest.BusinessLogic.Impl.Routes.Search;

internal class ByProvidersSearchStrategy : ISearchStrategy
{
    private readonly IReadOnlyCollection<IRoutesProvider> _providers;
    private readonly ILogger<ByProvidersSearchStrategy> _logger;

    public ByProvidersSearchStrategy(
        IEnumerable<IRoutesProvider> providers,
        ILogger<ByProvidersSearchStrategy> logger)
    {
        _providers = providers.ToList();
        _logger = logger;
    }

    public async Task<IReadOnlyCollection<RouteModel>> Search(
        SearchModel searchModel,
        CancellationToken token)
    {
        var tasks = _providers
            .Select(provider => provider.Search(searchModel, token))
            .ToArray();
        
        var tasksAwaiter = Task.WhenAll(tasks);
        try
        {
            await tasksAwaiter;
        }
        catch
        {
            if (tasksAwaiter.Exception is not null)
            {
                foreach (var ex in tasksAwaiter.Exception.InnerExceptions)
                {
                    _logger.LogError(ex, "An error occured while fetching routes");
                }
            }
        }

        return tasks
            .Where(task => task.IsCompletedSuccessfully)
            .SelectMany(task => task.Result)
            .ToList();
    }
}