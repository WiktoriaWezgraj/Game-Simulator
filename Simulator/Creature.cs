using System.ComponentModel.DataAnnotations;

using Simulator.Maps;
namespace Simulator;

public abstract class Creature
{

    public Map? Map { get; private set; }
    public Point Position { get; private set; }

    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null)
            throw new ArgumentNullException(nameof(map));
        if (!map.Exist(position))
            throw new ArgumentException("Position is out of map bounds.");

        Map = map;
        Position = position;
        map.Add(this, position);
    }


    private string _name = "Unknown";
    private int _level = 1;
    public string Name
    {
        get => _name;
        set
        {
            _name = Validator.Shortener(value, 3, 25, '#');

        }
    }

    public int Level
    {
        get => _level;
        set => _level = Validator.Limiter(value, 1, 10);
    }

    public abstract string Info { get; }

    public abstract int Power { get; }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }

    public string Go(Direction direction)
    {
        if (Map == null)
            return "The creature is not assigned to a map.";

        Point nextPosition = Map.Next(Position, direction);

        if (!nextPosition.Equals(Position))
        {
            Map.Move(this, Position, nextPosition);
            Position = nextPosition;
        }

        return $"Moved {direction.ToString().ToLower()} to {Position}.";
    }
}

