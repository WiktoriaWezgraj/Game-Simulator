using System;

namespace Simulator;

public class Orc : Creature
{
    public override char Symbol => 'O';
    public int _rage = 0;
    public int Rage
    {
        get => _rage;
        init => _rage = Validator.Limiter(value, 0, 10);
    }

    public override int Power => 7 * Level + 3 * Rage;

    public override string Info => $"{Name} [{Level}][{Rage}]";

    private int huntCount = 0;

    public Orc() : base() { }

    public Orc(string name, int level = 1, int rage = 1)
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
    }
    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
}

    

