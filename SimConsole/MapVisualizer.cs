﻿using Simulator.Maps;
using Simulator;
using System.Text;

namespace Simulator;

public class MapVisualizer
{
    private readonly Map _map;

    public MapVisualizer(Map map)
    {
        _map = map ?? throw new ArgumentNullException(nameof(map));
    }

    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Top border
        Console.Write(Box.TopLeft);
        for (int x = 0; x < _map.SizeX - 1; x++) 
        {
            Console.Write($"{Box.Horizontal}{Box.TopMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.TopRight}");

        // Map content
        for (int y = _map.SizeY - 1; y >= 0; y--)
        {
            Console.Write(Box.Vertical);
            for (int x = 0; x < _map.SizeX; x++)
            {
                var creatures = _map.At(x, y); //stwory na aktualnym polu
                if (creatures != null && creatures.Count > 1)
                {
                    Console.Write("X"); // wiecej niz jeden stwór
                }
                else if (creatures != null && creatures.Count == 1)
                {
                    var creature = creatures.First();
                    Console.Write(creature is Orc ? "O" : "E"); // O dla orka, E dla elfa
                }
                else
                {
                    Console.Write(" "); 
                }
                Console.Write(Box.Vertical); 
            }
            Console.WriteLine();

            if (y > 0)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < _map.SizeX - 1; x++)
                {
                    Console.Write($"{Box.Horizontal}{Box.Cross}");
                }
                Console.WriteLine($"{Box.Horizontal}{Box.MidRight}");
            }
        }

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < _map.SizeX - 1; x++)
        {
            Console.Write($"{Box.Horizontal}{Box.BottomMid}");
        }
        Console.WriteLine($"{Box.Horizontal}{Box.BottomRight}");

        Console.WriteLine();
    }
}

