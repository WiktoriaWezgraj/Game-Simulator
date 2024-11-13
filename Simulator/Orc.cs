using System;

namespace Simulator;

public class Orc : Creature
{
    
    public int _rage = 0;
    public int Rage
    {
        get => _rage;
        set => _rage = Validator.Limiter(value, 0, 10);
        //set
        //{
        //    if (_rage != 1)
        //        return;

        //    if (value < 1)
        //        value = 1;
        //    else if (value > 10)
        //        value = 10;

        //    _rage = value;
        //}
    }
    //public void Hunt() => Console.WriteLine($"{Name} is hunting.");

    public override int Power => 7 * Level + 3 * Rage;

    public override string Info => $"{Name} [{Level}][{Rage}]";

    private int huntCount = 0;

    public Orc() : base() { }

    public Orc(string name, int level, int rage = 1)
        : base(name, level)
    {
        Rage = rage;
        huntCount = 0;
    }

   

    public void Hunt()
    {
        huntCount++;

        if (huntCount % 2 == 0 && _rage < 10)
        {
            _rage++;
            huntCount = 0;
        }
        //Console.WriteLine($"{Name} is hunting");
    }
    public override string Greeting()
    {
        return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
    }
}

    

