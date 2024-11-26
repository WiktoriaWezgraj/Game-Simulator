using System.Drawing;

namespace Simulator.Maps
{
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
            if (Exist(p.Next(d))) return p.Next(d);
            return p;
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextDiagonalPoint = p.NextDiagonal(d);
            if (Exist(nextDiagonalPoint))
            {
                return nextDiagonalPoint;
            }
            return p;
        }
    }
}