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
        SmallSquareMap map = new(5);

        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        //List<Creature> creatures = [new Orc("Mańkus"), new Elf("Marcus"), new Orc("Shrekus")];

        List<Point> points = [new(2, 2), new(3, 1)];
        //List<Point> points = [new(2, 4), new(3, 8), new(4, 4)];

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
            Console.WriteLine($"<{simulation.CurrentCreature.GetType().Name} - {simulation.CurrentCreature.Info}> " +
                $"from {simulation.CurrentCreature.Position} goes {simulation.CurrentMoveName}");
            simulation.Turn();
            mapVisualizer.Draw();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        Console.WriteLine("The game is over. You didn’t win, but winning wasn't the goal. It's about enjoying the journey—so have fun!");
    }
}
