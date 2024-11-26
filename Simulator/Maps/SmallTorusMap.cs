using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
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

        public override void Move(Creature creature, Point from, Point to)
        {
            base.Move(creature, from, to);
        }

        public override List<Creature>? At(Point position)
        {
            return base.At(position);
        }

        public override List<Creature>? At(int x, int y)
        {
            return base.At(x, y);
        }

        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.Y >= 0 && p.X < SizeX && p.Y < SizeY;
        }

        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d); 
            return new Point((nextPoint.X + SizeX) % SizeX, (nextPoint.Y + SizeY) % SizeY);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextDiagonalPoint = p.NextDiagonal(d);
            return new Point((nextDiagonalPoint.X + SizeX) % SizeX, (nextDiagonalPoint.Y + SizeY) % SizeY);
        }
    }
}

