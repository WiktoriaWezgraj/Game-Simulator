using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public class Program
    {
        public static void Main()
        {
            BigBounceMap map = new BigBounceMap(8, 6);

            List<IMappable> mappables = new()
        {
            new Elf("Elandor"),
            new Orc("Gorbag"),
            new Animals { Description = "Rabbits", Size = 2 },
            new Birds { Description = "Ostriches", Size = 1, CanFly = false },
            new Birds { Description = "Eagles", Size = 1, CanFly = true }
        };

            List<Point> points = new()
        {
            new Point(1, 2),
            new Point(2, 5),
            new Point(3, 1),
            new Point(4, 5),
            new Point(0, 0)
        };

            string moves = "llllluuuuuuuuuuuurd";

            Simulation simulation = new(map, mappables, points, moves);
            MapVisualizer mapVisualizer = new(simulation.Map);

            // Wyświetlanie początkowych pozycji
            Console.WriteLine("Starting Positions: ");
            mapVisualizer.Draw();
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

            // Symulacja tur
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
}

