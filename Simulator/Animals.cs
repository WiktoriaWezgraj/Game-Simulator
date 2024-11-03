using System;
using System.ComponentModel.DataAnnotations;

namespace Simulator;
public class Animals
{
    public string _description = "Unknown description";
    public required string Description
    {
        get => _description;
        set
        {
            _description = Validator.Shortener(value, 3, 15, '#');
            //if (char.IsLower(value[0]))
            //    value = char.ToUpper(value[0]) + value.Substring(1);
        }
    }
        //    set
        //{
        //    if (_description != "Unknown description") //Sprawdzenie czy wartość została już nadana przy inicjacji, jeśli tak to funkcja wraca pusta, co nie pozwala na kolejną zmianę
        //        return;

        //    value = value.Trim();

        //    if (value.Length < 3)
        //        value = value.PadRight(3, '#');

        //    if (value.Length > 15)
        //    {
        //        value = value.Substring(0, 15).TrimEnd();
        //        if (value.Length < 3)
        //            value = value.PadRight(3, '#');
        //    }

        //    if (char.IsLower(value[0]))
        //        value = char.ToUpper(value[0]) + value.Substring(1);

        //    _description = value;
        //}
    
    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
    
}
