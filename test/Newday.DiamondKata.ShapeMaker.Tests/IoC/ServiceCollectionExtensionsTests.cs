using Microsoft.Extensions.DependencyInjection;
using Newday.DiamondKata.ShapeMaker.Interfaces;
using Newday.DiamondKata.ShapeMaker.IoC;
using Newday.DiamondKata.ShapeMaker.Services;

namespace Newday.DiamondKata.ShapeMaker.Tests.IoC;

public class ServiceCollectionExtensionsTests
{
    [Fact]
    public void AddDiamondMakerService_RegistersExpectedService()
    {
        var serviceProvider = new ServiceCollection()
            .AddDiamondMakerService()
            .BuildServiceProvider();
        var service = serviceProvider.GetService<IStringShapeMaker>();
        
        Assert.NotNull(service);
        Assert.IsType<DiamondStringMaker>(service);
    }
}