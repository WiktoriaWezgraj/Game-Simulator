using Simulator.Maps;

namespace Simulator;

public class SimulationHistory
{
    private readonly List<State> _history = new();


    public void Save(int turn, Dictionary<IMappable, Point> positions, IMappable currentMappable, Direction? currentMove) =>
        _history.Add(new State
        {
            Turn = turn,
            Positions = new Dictionary<IMappable, Point>(positions),
            CurrentMappable = currentMappable,
            CurrentMove = currentMove
        });


    public void ShowState(int turn)
    {
        if (turn < 0 || turn >= _history.Count)
        {
            throw new ArgumentException("Invalid turn count.");
        }
    }

    private class State
    {
        public int Turn { get; set; }
        public Dictionary<IMappable, Point> Positions { get; set; } = new();
        public IMappable? CurrentMappable { get; set; }
        public Direction? CurrentMove { get; set; }
    }
}


