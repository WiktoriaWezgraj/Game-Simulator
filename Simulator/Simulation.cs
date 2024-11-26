using Simulator.Maps;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace Simulator;

public class Simulation
{
    private int currentCreatureIndex = 0;

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

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
            var direction = DirectionParser.Parse(Moves[currentCreatureIndex % Moves.Length].ToString());
            if (direction.Any()) return direction[0].ToString().ToLower();

            return string.Empty;
        }
    }

    private HashSet<char> validMove = new HashSet<char> { 'l', 'r', 'u', 'd' };
    private string ValidateMoves(string moves) => new(moves.Where(c => validMove.Contains(Char.ToLower(c))).ToArray());

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures == null || creatures.Count == 0)
            throw new ArgumentException("Creatures list cannot be empty.");
        if (positions == null || positions.Count != creatures.Count)
            throw new ArgumentException("Number of positions must match number of creatures.");
        if (string.IsNullOrWhiteSpace(moves))
            throw new ArgumentException("Moves cannot be null or empty.");

        Map = map ?? throw new ArgumentNullException(nameof(map));
        Creatures = creatures;
        Positions = positions;
        Moves = ValidateMoves(moves);
        for (int i = 0; i < creatures.Count; i++)
        {
            Creatures[i].InitMapAndPosition(Map, Positions[i]);
        }
    }
    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished)
        {
            throw new InvalidOperationException("Simulation is already finished.");
        }


        try
        {
            var direction = DirectionParser.Parse(Moves[currentCreatureIndex % Moves.Length].ToString())[0];
            CurrentCreature.Go(direction);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Illegal move for creature {CurrentCreature}: {ex.Message}");
        }
        currentCreatureIndex++;

        if (currentCreatureIndex >= Moves.Length)
        {
            Finished = true;
        }

    }
}

