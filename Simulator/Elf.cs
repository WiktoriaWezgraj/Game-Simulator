using System;

namespace Simulator;

public class Elf : Creature
{

    public int _agility = 0;
    public int Agility
    {
        get => _agility;
        set => _agility = Validator.Limiter(value, 0, 10);
        //set
        //{
        //    if (_agility != 1)
        //        return;

        //    if (value < 1)
        //        value = 1;
        //    else if (value > 10)
        //        value = 10;

        //    _agility = value;
        //}
    }

    //public void Sing() => Console.WriteLine($"{Name} is singing.");

    public override int Power => 8 * Level + 2 * Agility;

    public override string Info => $"{Name} [{Level}][{Agility}]";

    int singCount = 0;


    public Elf() : base() { }

    public Elf(string name, int level= 1, int agility = 0) : base(name, level)
    {
        singCount = 0;
        Agility = agility;
    }


    public void Sing()
    {

        singCount++;

        if (singCount % 3 == 0 && _agility < 10)
        {
            _agility++;
            singCount = 0;
        }

        //Console.WriteLine($"{Name} is singing.");
    }

    //public override string Greeting()
    //{
    //    return $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";
    //}

}
