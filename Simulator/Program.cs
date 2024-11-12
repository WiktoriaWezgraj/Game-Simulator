using Simulator.Maps;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Simulator;

internal class Program
{
    static void Lab5a()
    {
   

        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));
        Console.WriteLine(p.NextDiagonal(Direction.Right));

        var rectangle = new Rectangle(new Point(1, 2), new Point(4, 3));
        Console.WriteLine(rectangle.ToString());

        var rectangle1 = new Rectangle(new Point(-1, 3), new Point(1, -3));
        Console.WriteLine(rectangle1.ToString());

        Rectangle r = new(1, 2, 3, 4);

        //var rectangle2;
        try
        {
            var rectangle2 = new Rectangle(new Point(-1, 1), new Point(-1, 1));
            Console.WriteLine(rectangle2.ToString());
        }
        catch (ArgumentException exc) { 
            Console.WriteLine(exc.Message);
        }
        //var rectangle3 = new Rectangle(new Point(-1, 1), new Point(-1, 1));
        //Console.WriteLine(rectangle3.ToString());
        Console.WriteLine(rectangle1.Contains(new Point(1, 2)));

    }

    static void Lab5b()
    {
        SmallSquareMap sqMap = new SmallSquareMap(11);

        Point newPoint = new Point(0, 0);
        Console.WriteLine(newPoint);

        newPoint = sqMap.Next(newPoint, Direction.Down); //zwraca punkt początkowy, bo wychodzi poza mapę
        Console.WriteLine(newPoint);
        newPoint = sqMap.NextDiagonal(newPoint, Direction.Up);
        Console.WriteLine(newPoint);
        newPoint = sqMap.NextDiagonal(newPoint, Direction.Left);
        Console.WriteLine(newPoint);

        try
        {
            SmallSquareMap sqMap2 = new SmallSquareMap(1);
        }
        catch (ArgumentOutOfRangeException exc)
        {
            Console.WriteLine(exc.Message);
        }
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Lab5a();
        Lab5b();
    }
}

