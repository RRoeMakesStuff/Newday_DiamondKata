using System.Text;
using Newday.DiamondKata.ShapeMaker.Interfaces;

namespace Newday.DiamondKata.ShapeMaker.Services;

public class DiamondStringMaker: IStringShapeMaker
{
    public string CalculateShapeString(char letter)
    {
        if (!char.IsLetter(letter) || !char.IsUpper(letter))
        {
            throw new ArgumentException("Argument is required to be an uppercase letter");
        }

        var size = letter - 'A' + 1;
        var sb = CalculateTopHalf(new StringBuilder(), size);
        sb = CalculateBottomHalf(sb, size);
        
        return sb.ToString();
    }

    private StringBuilder CalculateTopHalf(StringBuilder sb, int size)
    {
        for (int i = 0; i < size; i++)
        {
            char currentLetter = (char)('A' + i);
            int padding = size - i - 1;

            sb.Append(' ', padding);
            sb.Append(currentLetter);

            if (currentLetter != 'A')
            {
                sb.Append(' ', 2 * i - 1);
                sb.Append(currentLetter);
            }

            sb.Append('\n');
        }

        return sb;
    }
    
    private StringBuilder CalculateBottomHalf(StringBuilder sb, int size)
    {
        for (int i = size - 2; i >= 0; i--)
        {
            char currentLetter = (char)('A' + i);
            int padding = size - i - 1;

            sb.Append(' ', padding);
            sb.Append(currentLetter);

            if (currentLetter != 'A')
            {
                sb.Append(' ', 2 * i - 1);
                sb.Append(currentLetter);
            }

            sb.Append('\n');
        }

        return sb;
    }
}