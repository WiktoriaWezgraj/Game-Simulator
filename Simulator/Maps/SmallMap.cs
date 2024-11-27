namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly List<IMappable>?[,] _fields;

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
        _fields = new List<IMappable>?[sizeX, sizeY];
    }

    //add, remove, at ...
    public override void Add(IMappable mappable, Point position)
    {
        _fields[position.X, position.Y] ??= new List<IMappable>();

        _fields[position.X, position.Y]?.Add(mappable);
    }
    public override void Move(IMappable mappable, Point from, Point to)
    {
        {
            if (!Exist(from) || !Exist(to)) throw new ArgumentException("Position is out of map!");
            Remove(mappable, from);
            Add(mappable, to);
        }
    }
    public override void Remove(IMappable mappable, Point position)
    {
        _fields[position.X, position.Y]?.Remove(mappable);

        if (_fields[position.X, position.Y]?.Count == 0)
            _fields[position.X, position.Y] = null;
    }
    public override List<IMappable>? At(int x, int y) => At(new Point(x, y));
    public override List<IMappable>? At(Point point)
    {
        return _fields[point.X, point.Y];
    }
}
// dodajemy public readonly Finished, currentmappable {get ;} ktory stwor sie bedzie ruszal i nazwa ruchu,
// turn - bierzemy stwora bierzemy ruch i mowimy stworowi zeby wykonal ten ruch
//na konsoli symulacja jak to dziala - klasa mapvisualizer po kazdym ruchu rysujemy mape zwierzaczków