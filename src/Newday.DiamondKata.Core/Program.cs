using Microsoft.Extensions.DependencyInjection;

namespace Newday.DiamondKata.Core;

public class Program
{
    private readonly IHandler _handler;

    public Program(IHandler handler)
    {
        _handler = handler;
    }

    public void Run(string[] args)
    {
        _handler.Run(args);
    }

    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .ConfigureServices()
            .BuildServiceProvider();

        var program = new Program(serviceProvider.GetService<IHandler>());

        program.Run(args);
    }
}