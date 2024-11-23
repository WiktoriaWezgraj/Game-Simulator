using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    List<Creature>?[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too tall");
        }
        _fields = new List<Creature>?[sizeX, sizeY];
    }

    //add, remove, at ...
    public override void Add(Creature creature, Point position)
    {
        if (!Exist(position))
        {
            throw new NotImplementedException();
        }
        _fields[position.X, position.Y] ??= new List<Creature>();
        _fields[position.X, position.Y]!.Add(creature);

    }
    public override void Remove(Creature creature, Point position)
    {
        _fields[position.X, position.Y]!.Remove(creature);
    }
    public override void Move(Creature creature, Point from, Point to)
    {
        Remove(creature, from);
        Add(creature, to);
    }
    public override void At(Point position)
    {
        new Point(position.X, position.Y);
    }
    public override void At(int x, int y)
    {
        new Point(x, y);
    }


}
// dodajemy public readonly Finished, currentcreature {get ;} ktory stwor sie bedzie ruszal i nazwa ruchu,
// turn - bierzemy stwora bierzemy ruch i mowimy stworowi zeby wykonal ten ruch
//na konsoli symulacja jak to dziala - klasa mapvisualizer po kazdym ruchu rysujemy mape zwierzaczków