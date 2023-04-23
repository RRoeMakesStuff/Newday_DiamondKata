using Moq;

namespace Newday.DiamondKata.Core.Tests;

public class ProgramTests
{
    private static Mock<IHandler> _mockHandler;

    public ProgramTests()
    {
        _mockHandler = new Mock<IHandler>();
    }
    
    [Fact]
    public void Run_CallsHandlerWithArgs()
    {
        var args = new[] { "a" };
        
        GetSut().Run(args);
        
        _mockHandler.Verify(x => x.Run(args), Times.Once);
    }

    private static Program GetSut() => new(_mockHandler.Object);
}