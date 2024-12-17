using System;
using System.Collections.Generic;
using System.Drawing;
using Simulator;

namespace Simulator.Maps
{
    public class Program
    {
        public static void Main()
        {
            // Tworzenie mapy
            Map map = new BigBounceMap(8, 6);

            // Lista obiektów poruszających się po mapie
            List<IMappable> mappables = new()
            {
                new Elf("Elandor"),
                new Orc("Gorbag"),
                new Animals { Description = "Rabbits", Size = 2 },
                new Birds { Description = "Ostriches", Size = 1, CanFly = false },
                new Birds { Description = "Eagles", Size = 1, CanFly = true }
            };

            // Początkowe pozycje obiektów
            List<Point> positions = new()
            {
                new Point(1, 2),
                new Point(2, 5),
                new Point(3, 1),
                new Point(4, 5),
                new Point(0, 0)
            };

            // Ciąg ruchów
            string moves = "llllluuuuuuuurrrrrrrrrrrrrrrrrrrd";

            // Inicjalizacja symulacji i historii
            Simulation simulation = new(map, mappables, positions, moves);
            MapVisualizer mapVisualizer = new(map);

            Console.WriteLine("Simulation Started!\n");
            int turn = 0;
            while (!simulation.Finished)
            {
                Console.WriteLine($"Turn {turn}:");
                Console.WriteLine($"{simulation.CurrentMappable.GetType().Name} - {simulation.CurrentMappable.Info} " +
                $"from {simulation.CurrentMappable.Position} goes {simulation.CurrentMoveName}");
                simulation.Turn();
                mapVisualizer.Draw();
                turn++;
            }

            Console.WriteLine("Simulation Finished!");
        }
    }
}

