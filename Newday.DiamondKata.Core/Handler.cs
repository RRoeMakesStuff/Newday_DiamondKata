using Newday.DiamondKata.ShapeMaker.Interfaces;

namespace Newday.DiamondKata.Core;

public class Handler: IHandler
{
    private readonly IStringShapeMaker _stringShapeMaker;
    
    public Handler(IStringShapeMaker stringShapeMaker)
    {
        _stringShapeMaker = stringShapeMaker;
    }
    public void Run(string[] args)
    {
        if (args.Length != 1)
        {
            throw new ArgumentException($"Expected 1 argument, received {args.Length}");
        }

        if (Char.TryParse(args[0].ToUpper(), out var letter))
        {
            Console.Write(_stringShapeMaker.CalculateShapeString(letter));
        }
        
        else
        {
            throw new ArgumentException($"Value '{args[0]} cannot be converted to alphabetical char, please enter single alphabetical char");
        }
    }
}