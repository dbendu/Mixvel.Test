using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

namespace MixvelTest.DataAccess.RouteProviders.Http.Configs;

internal class RouteProviderHttpClientConfig
{
    [Required]
    public required string BaseUrl { get; [UsedImplicitly] set; }
    
    [Required]
    public TimeSpan Timeout { get; [UsedImplicitly] set; }
}