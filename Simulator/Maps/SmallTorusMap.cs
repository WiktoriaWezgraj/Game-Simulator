using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

        public override bool Exist(Point p) => true;

        public override Point Next(Point p, Direction d)
        {
            var nextPoint = base.Next(p, d);
            return new Point((nextPoint.X + SizeX) % SizeX, (nextPoint.Y + SizeY) % SizeY);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextDiagonalPoint = base.NextDiagonal(p, d);
            return new Point((nextDiagonalPoint.X + SizeX) % SizeX, (nextDiagonalPoint.Y + SizeY) % SizeY);
        }
    }

}

