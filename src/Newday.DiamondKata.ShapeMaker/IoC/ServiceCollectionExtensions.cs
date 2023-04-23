using Microsoft.Extensions.DependencyInjection;
using Newday.DiamondKata.ShapeMaker.Interfaces;
using Newday.DiamondKata.ShapeMaker.Services;

namespace Newday.DiamondKata.ShapeMaker.IoC;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDiamondMakerService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient<IStringShapeMaker, DiamondStringMaker>();
        return serviceCollection;
    }
}