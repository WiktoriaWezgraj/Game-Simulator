using Simulator.Maps;
using Simulator;
using System.Text;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        SmallTorusMap map2 = new(6, 7);
        List<Creature> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new Simulation(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new MapVisualizer(map);
        mapVisualizer.Draw();
        simulation.Turn();
        mapVisualizer.Draw();
        simulation.Turn();
        mapVisualizer.Draw();
        simulation.Turn();
        mapVisualizer.Draw();
        simulation.Turn();
        mapVisualizer.Draw();
    }
}
