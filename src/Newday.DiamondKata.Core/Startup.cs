using Microsoft.Extensions.DependencyInjection;
using Newday.DiamondKata.ShapeMaker.IoC;

namespace Newday.DiamondKata.Core;

public static class Startup
{
    public static IServiceCollection ConfigureServices(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddDiamondMakerService()
            .RegisterHandler();

        return serviceCollection;
    }

    private static void RegisterHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IHandler, Handler>();
    }
}