using Newday.DiamondKata.ShapeMaker.Interfaces;
using Newday.DiamondKata.ShapeMaker.Services;

namespace Newday.DiamondKata.ShapeMaker.Tests.Services;

public class DiamondStringMakerTests
{
    [Theory]
    [InlineData('A', "A")]
    [InlineData('B', " A \nB B\n A ")]
    [InlineData('C', "  A  \n B B \nC   C\n B B \n  A  ")]
    public void CalculateShapeString_ReturnsExpectedString(char letter, string expectedString)
    {
        var result = GetSut().CalculateShapeString(letter);
        Assert.Equal(expectedString, result);
    }
    
    [Theory]
    [InlineData('a')]
    [InlineData('z')]
    public void CalculateShapeString_ThrowsArgumentException_WhenLetterIsNotUppercase(char letter)
    {
        var error = Assert.Throws<ArgumentException>(() => GetSut().CalculateShapeString(letter));
        Assert.Equal("Argument is required to be an uppercase letter", error.Message);
    }
    
    [Theory]
    [InlineData('1')]
    [InlineData('@')]
    public void CalculateShapeString_ThrowsArgumentException_WhenCharIsNotAlphabetical(char character)
    {
        var error = Assert.Throws<ArgumentException>(() => GetSut().CalculateShapeString(character));
        Assert.Equal("Argument is required to be an uppercase letter", error.Message);
    }


    private static IStringShapeMaker GetSut() => new DiamondStringMaker();
}