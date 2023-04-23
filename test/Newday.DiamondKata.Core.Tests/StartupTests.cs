using Microsoft.Extensions.DependencyInjection;
using Newday.DiamondKata.ShapeMaker.Interfaces;

namespace Newday.DiamondKata.Core.Tests;

public class StartupTests
{
    [Fact]
    public void ConfigureServices_RequiredServicesAdded()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.ConfigureServices();
        
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var handler = serviceProvider.GetService<IHandler>();
        var diamondMaker = serviceProvider.GetService<IStringShapeMaker>();
        Assert.NotNull(handler);
        Assert.NotNull(diamondMaker);
    }
}