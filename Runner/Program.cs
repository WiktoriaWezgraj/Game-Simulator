using Simulator.Maps;
using System;
using System.Diagnostics;
using System.Runtime.Intrinsics;
using System.Text;

namespace Simulator;

public class Program
{
    static void Main(string[] args)
    {
        List<Creature> creatures = new List<Creature>
            {
                new Elf {Name= "Eleandor", Level = 5, Agility = 10},
                new Orc {Name= "Marcus", Level = 8, Rage = 2 },
                new Elf {Name= "David", Level = 3, Agility = 8},
                new Orc {Name= "Marie", Level = 6, Rage = 10 },
                new Elf {Name= "Arthur", Level = 10, Agility = 5},
                new Orc {Name= "Wigzo", Level = 7, Rage = 4 }
            };

        creatures.Sort((c1, c2) => c1.Power.CompareTo(c2.Power));

        Console.WriteLine("Lista stworów posortowana według mocy:");
        foreach (var creature in creatures)
        {
            Console.WriteLine(creature);
        }
    }
}

