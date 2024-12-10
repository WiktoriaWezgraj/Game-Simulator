namespace Simulator.Maps;

public interface IMappable
{
    string Info { get; }
    Point Position { get; }
    char Symbol { get; }
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point point);
}
