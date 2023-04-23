using Moq;
using Newday.DiamondKata.ShapeMaker.Interfaces;

namespace Newday.DiamondKata.Core.Tests;

public class HandlerTests
{
    private static Mock<IStringShapeMaker> _mockStringShapeMaker;

    public HandlerTests()
    {
        _mockStringShapeMaker = new Mock<IStringShapeMaker>();
    }

    [Fact]
    public void Run_CallsShapeMaker_WhenAllConditionsValid()
    {
        var testInput = "C";
        _mockStringShapeMaker.Setup(x => x.CalculateShapeString(It.IsAny<char>()))
            .Returns("ANY STRING");

        GetSut().Run(new[] { testInput });
        
        _mockStringShapeMaker.Verify(x => x.CalculateShapeString(It.IsAny<char>()), Times.Once);
    }

    [Fact]
    public void Run_CallsShapeMakerWithUppercase_WhenHandedLowercaseChar()
    {
        var testInput = "c";
        _mockStringShapeMaker.Setup(x => x.CalculateShapeString(It.IsAny<char>()))
            .Returns("ANY STRING");

        GetSut().Run(new[] { testInput });
        
        _mockStringShapeMaker.Verify(x => x.CalculateShapeString('C'), Times.Once);
    }

    [Theory]
    [InlineData(new object[] { new string[0]  })]
    [InlineData(new object[] { new[] { "A", "B" } })]
    public void Run_ThrowsArgumentException_WhenInputIsNotLengthOne(string[] args)
    {
        var error = Assert.Throws<ArgumentException>(() => GetSut().Run(args));
        Assert.Equal($"Expected 1 argument, received {args.Length}", error.Message);
    }
    
    [Theory]
    [InlineData("ABC")]
    [InlineData("")]
    public void Run_ThrowsArgumentException_WhenInputIsNotSingleCharacter(string input)
    {
        var error = Assert.Throws<ArgumentException>(() => GetSut().Run(new []{input}));
        Assert.Contains("cannot be converted to alphabetical char, please enter single alphabetical char", error.Message);
    }

    private static IHandler GetSut() => new Handler(_mockStringShapeMaker.Object);
}