using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point p, Direction d)
    {
        int x = p.X;
        int y = p.Y;

        switch(d)
        {
            case Direction.Up:
                y = (y + 1) % SizeY;
                    break;
            case Direction.Down:
                y = (y - 1 + SizeY) % SizeY;
                break;
            case Direction.Left:
                x = (x - 1 + SizeX) % SizeX;
                break;
            case Direction.Right:
                x = (x + 1) % SizeX;
                break;
        }
        return new Point(x, y);
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        int x = p.X;
        int y = p.Y;

        switch (d)
        {
            case Direction.Up:
                x = (x + 1) % SizeX;
                y = (y + 1) % SizeY;
                break;
            case Direction.Down:
                x = (x - 1 + SizeX) % SizeX;
                y = (y - 1 + SizeY) % SizeY;
                break;
            case Direction.Left:
                x = (x - 1 + SizeX) % SizeX;
                y = (y + 1) % SizeY;
                break;
            case Direction.Right:
                x = (x + 1) % SizeX;
                y = (y - 1 + SizeY) % SizeY;
                break;
        }
        return new Point(x, y);
    }
}
