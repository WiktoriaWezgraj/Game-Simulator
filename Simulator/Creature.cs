using System.ComponentModel.DataAnnotations;

namespace Simulator;

public abstract class Creature
{
    private string _name = "Unknown";
    private int _level = 1;
    public string Name
    {
        get => _name;
        set
        {
            _name = Validator.Shortener(value, 3, 25, '#');
            //if (char.IsLower(value[0]))
            //    value = char.ToUpper(value[0]) + value.Substring(1);
        }
    }
            //set
            //{
            //    if (_name != "Unknown") //Sprawdzenie czy wartość została już nadana przy inicjacji, jeśli tak to funkcja wraca pusta, co nie pozwala na kolejną zmianę
            //        return;

            //    value = value.Trim();

            //    if (value.Length < 3)
            //        value = value.PadRight(3, '#');

            //    if (value.Length > 25)
            //    {
            //        value = value.Substring(0, 25).TrimEnd();
            //        if (value.Length < 3)
            //            value = value.PadRight(3, '#');
            //    }

            //    if (char.IsLower(value[0]))
            //        value = char.ToUpper(value[0]) + value.Substring(1);

            //    _name = value;
            //}
     
    public int Level
    {
        get => _level;
        set => _level = Validator.Limiter(value, 1, 10);
        //set
        //{
        //    if (_level != 1) 
        //        return;

        //    if (value < 1)
        //        value = 1;
        //    else if (value > 10)
        //        value = 10;

        //    _level = value;
        //}
    }

    public abstract string Info { get; }

    public abstract int Power { get; }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }

    //public string Info => $"{Name} <{Level}>";

    public abstract void SayHi();

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";

    public void Upgrade()
    {
        if (_level < 10)
            _level++;
    }
    public void Go(Direction direction)
    {
        string directionLower = direction.ToString().ToLower(); 
        Console.WriteLine($"{_name} goes {directionLower}");
    }

    public void Go(Direction[] directions) 
                                           
    {
        foreach (Direction direction in directions) 
        {
            Go(direction);
        }
    }

    public void Go(string letters)
    {
        Direction[] parsedDirections = DirectionParser.Parse(letters);
        Go(parsedDirections);
    }
}

