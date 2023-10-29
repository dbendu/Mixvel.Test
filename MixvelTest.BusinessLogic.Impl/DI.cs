using Microsoft.Extensions.DependencyInjection;
using MixvelTest.BusinessLogic.Impl.Context;
using MixvelTest.BusinessLogic.Impl.Routes;

namespace MixvelTest.BusinessLogic.Impl;

internal static class BusinessLogicRegistration
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        return services
            .AddRequestContext()
            .AddRoutes();
    }
}