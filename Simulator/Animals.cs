using Simulator.Maps;
using System;
using System.ComponentModel.DataAnnotations;

namespace Simulator;
public class Animals : IMappable
{
    public string _description = "Unknown description";
    public required string Description
    {
        get => _description;
        init
        {
            _description = Validator.Shortener(value, 3, 15, '#');
           
        }
    }

    public Point Position { get; protected set; } 
    public virtual char Symbol => 'A';
    public Map? Map { get; private set; }

    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public virtual void Go(Direction direction)
    {
        if (Map == null) throw new InvalidOperationException("Animal cannot move since it's not on the map!");

        var newPosition = Map.Next(Position, direction);

        Map.Move(this, Position, newPosition);
        Position = newPosition;
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (Map != null) throw new InvalidOperationException("Animal is already on a map.");
        if (!map.Exist(point)) throw new ArgumentException("Position does not exist");

        Map = map;
        Position = point;
        map.Add(this, point);
    }

    protected virtual Point GetNewPosition(Direction direction)
    {
        return Map.Next(Position, direction);
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
    
}

//directionparser wywolac w konstruktorze????
//zalozenia zadania LAB-8: istnienie prostokatnej mapy; symulacja odbywa sie w turach, wojna- moga byc ranni, np. pol zdrowia, potem umiera
//drzewa, lasy, gory, jedni potrafia przejsc a niektorzy nie; 
//orki sa mocniejsze w nocy a elfy w dzien
//projekt zaliczeniowy: to samo tylko z ustalonymi zalozeniami w kodzie

