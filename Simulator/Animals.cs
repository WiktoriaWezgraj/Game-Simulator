using System;

namespace Simulator;

public class Animals
{
    public required string Description { get; init; } = "Dogs";
    public uint Size { get; set; } = 3;
    //public Animals(string description, uint size)
    //{
    //    Description = description;
    //    Size = size;
    //}

    public string Info() => $"{Description} <{Size}>";
}
