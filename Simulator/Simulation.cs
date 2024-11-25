using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Simulator;

public class Simulation
{
    //private int currentMoveIndex = 0;
    private int currentCreatureIndex = 0;
    public Dictionary<Creature, Point> creaturePositions;

    public Map Map { get; }
    public List<Creature> Creatures { get; }
    public List<Point> Positions { get; }
    public string Moves { get; }
    public bool Finished { get; private set; } = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature
    {
        get
        {
            return Creatures[currentCreatureIndex % Creatures.Count];
        }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get
        {
            return Moves[currentCreatureIndex].ToString();
        }
    }

    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.");
        if (positions == null || positions.Count != creatures.Count)
            throw new ArgumentException("Number of positions must match number of creatures.");
        if (string.IsNullOrWhiteSpace(moves))
            throw new ArgumentException("Moves cannot be null or empty.");

        Map = map;
        Creatures = creatures;
        Positions = positions;
        for (int i = 0; i < creatures.Count; i++)
        {
            Creatures[i].InitMapAndPosition(Map, Positions[i]);
        }
        Moves = DirectionParser.Parse(moves).ToString();
    }

    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation is already finished.");
        }

        CurrentCreature.Go(DirectionParser.Parse(CurrentMoveName)[0]);
        currentCreatureIndex++;

        if (currentCreatureIndex >= Moves.Length)
        {
            Finished = true;
        }
    }
}

