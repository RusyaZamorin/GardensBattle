using System;

namespace GardensBattle.Runtime.Gameplay
{
    [Serializable]
    public class ShapePoint
    {
        public int X;
        public int Y;

        public ShapePoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}