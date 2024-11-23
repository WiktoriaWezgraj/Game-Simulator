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
           
        }
    }
    
    public uint Size { get; set; } = 3;

    public virtual string Info => $"{Description} <{Size}>";

    public override string ToString() => $"{GetType().Name.ToUpper()}: {Info}";
    
}
