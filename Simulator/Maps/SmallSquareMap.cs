using System.Drawing;

namespace Simulator.Maps;

public class SmallSquareMap : Map 
{
    public int Size { get; }
    public Rectangle Rec;


    public SmallSquareMap(int size) 
    {
        if (size < 5 || size > 20)
        {
            throw new ArgumentOutOfRangeException("Zły rozmiar");
        }
        Size = size;
        Rec = new Rectangle(new Point(0, 0), new Point(Size - 1, Size - 1));
    }


    public override bool Exist(Point p) 
    {
        return Rec.Contains(p);
    }

    public override Point Next(Point p, Direction d)
    {
        if(Exist(p.Next(d)))
        {
            return p.Next(d);
        }
        return p;
        
    }
    public override Point NextDiagonal(Point p, Direction d)
    {
        if (Exist(p.NextDiagonal(d)))
        {
            return p.NextDiagonal(d);
        }
        return p;
    }
}