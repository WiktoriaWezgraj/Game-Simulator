using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        //SmallSquareMap map = new(9);
        SmallSquareMap map = new(6);

        List<IMappable> creatures = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 2 },
            new Birds { Description = "Ostriches", Size = 1, CanFly = true },
            new Birds { Description = "Eagles", Size = 1, CanFly = false },
        };

        List<Point> points = new()
        {
            new Point(1, 2),
            new Point(4, 5),
            new Point(3, 1),
            new Point(4, 4),
            new Point(0, 0)
        };

        //string moves = "dlrludl";
        string moves = "rrddlluu";
        //string moves = "dlrudul";
        //string moves = "uuuuuuuuuu";

        Simulation simulation = new Simulation(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(map);

        Console.WriteLine("Starting Positions: ");
        mapVisualizer.Draw();
        Console.WriteLine("Press any key to continue...");
        Console.ReadLine();
        while (!simulation.Finished)
        {
            Console.WriteLine($"<{simulation.CurrentMappable.GetType().Name} - {simulation.CurrentMappable.Info}> " +
                $"from {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}");
            simulation.Turn();
            mapVisualizer.Draw();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        Console.WriteLine("The game is over. You didn’t win, but winning wasn't the goal. It's about enjoying the journey—so have fun!");
    }
}
