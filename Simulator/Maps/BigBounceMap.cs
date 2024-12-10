using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public class BigBounceMap : BigMap
    {
        public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

        private Direction ReflectDirection(Direction d)
        {
            switch (d)
            {
                case Direction.Left:
                    return Direction.Right;

                case Direction.Right:
                    return Direction.Left;

                case Direction.Up:
                    return Direction.Down;

                case Direction.Down:
                    return Direction.Up;
            }
            return d;
        }

        public override Point Next(Point p, Direction d)
        {
            Point position = p.Next(d);

            if (Exist(position))
                return position;

            Direction reflectedDirection = ReflectDirection(d);
            position = p.Next(reflectedDirection);

            if (Exist(position))
                return position;

            return p;

        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            Point position = p.NextDiagonal(d);

            if (Exist(position))
                return position;

            Direction reflectedDirection = ReflectDirection(d);
            position = p.NextDiagonal(reflectedDirection);

            if (Exist(position))
                return position;

            return p;
        }
    }
}
