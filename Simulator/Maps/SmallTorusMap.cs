using System;
using System.Collections.Generic;
using System.Drawing;

namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) 
        {
            FNext = MapMovement.SmallTorusNext;
            FNextDiagonal = MapMovement.SmallTorusNextDiagonal;
        }

        public override bool Exist(Point p) => true;
    }

}

