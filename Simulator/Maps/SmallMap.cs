namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide");
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Too tall");
        }
    }
}
// dodajemy public readonly Finished, currentmappable {get ;} ktory stwor sie bedzie ruszal i nazwa ruchu,
// turn - bierzemy stwora bierzemy ruch i mowimy stworowi zeby wykonal ten ruch
//na konsoli symulacja jak to dziala - klasa mapvisualizer po kazdym ruchu rysujemy mape zwierzaczków