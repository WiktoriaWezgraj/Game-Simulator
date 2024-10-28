using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Creature creature = new Creature("Harry",2);
        creature.SayHi();

        //Animals zwierze = new Animals();


        //public string AnimalInfo = zwierze.Info();
        //Console.WriteLine(AnimalInfo);

        //Console.ReadLine();
    }

    
}
