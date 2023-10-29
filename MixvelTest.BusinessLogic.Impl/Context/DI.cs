using Microsoft.Extensions.DependencyInjection;

namespace MixvelTest.BusinessLogic.Impl.Context;

internal static class RequestContextRegistration
{
    public static IServiceCollection AddRequestContext(this IServiceCollection services)
    {
        return services
            .AddScoped<RequestContext>();
    }
}