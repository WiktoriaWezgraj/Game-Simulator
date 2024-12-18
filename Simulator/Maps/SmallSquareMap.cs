using System.Drawing;

namespace Simulator.Maps
{
    public class SmallSquareMap : SmallMap
    {
        public SmallSquareMap(int size) : base(size, size) 
        {
            FNext = MapMovement.WallNext;
            FNextDiagonal = MapMovement.WallNextDiagonal;
            //w ten sam sposob robimy w bouncy i torusie
        }
        
    }
}