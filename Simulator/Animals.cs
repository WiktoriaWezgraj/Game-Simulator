using System;

namespace Simulator;
public class Animals
{
    private string _description = "Unknown description";
    public required string Description
    {
        get => _description;
        set
        {
            if (_description != "Unknown description") //Sprawdzenie czy wartość została już nadana przy inicjacji, jeśli tak to funkcja wraca pusta, co nie pozwala na kolejną zmianę
                return;

            value = value.Trim();

            if (value.Length < 3)
                value = value.PadRight(3, '#');

            if (value.Length > 15)
            {
                value = value.Substring(0, 15).TrimEnd();
                if (value.Length < 3)
                    value = value.PadRight(3, '#');
            }

            if (char.IsLower(value[0]))
                value = char.ToUpper(value[0]) + value.Substring(1);

            _description = value;
        }
    }
    public uint Size { get; set; } = 3;

    public string Info => $"{Description} <{Size}>";
}
