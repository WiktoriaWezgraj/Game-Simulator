using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

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

    public override Point Next(Point p, Direction d)
    {
        Point p1 = p.Next(d);
        return new Point((p1.X + SizeX) % SizeX, (p1.Y + SizeY) % SizeY);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point p1 = p.NextDiagonal(d);
        return new Point((p1.X + SizeX) % SizeX, (p1.Y + SizeY) % SizeY);
    }
}
