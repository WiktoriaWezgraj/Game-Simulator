using System.Drawing;

namespace Simulator.Maps;

public class SmallSquareMap : SmallMap 
{
    public SmallSquareMap(int size) : base(size, size) { }

    public override void Add(Creature creature, Point position)
    {
        base.Add(creature, position);
    }
    public override void Remove(Creature creature, Point position)
    {
        base.Remove(creature, position);
    }
    public override void Move(Creature creature, Point position, Point position2)
    {
        base.Move(creature, position, position2);
    }
    public override void At(Point position)
    {
        base.At(position);
    }

    public override void At(int x, int y)
    {
        base.At(x, y);
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