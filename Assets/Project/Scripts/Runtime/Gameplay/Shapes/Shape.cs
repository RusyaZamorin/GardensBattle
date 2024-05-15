using System;
using System.Collections.Generic;
using System.Linq;

namespace GardensBattle.Runtime.Gameplay.Shapes
{
    [Serializable]
    public class Shape
    {
        public ShapePoint Center => Points.First(p => p is { X: 0, Y: 0 });
        public List<ShapePoint> Points;

        public Shape(List<ShapePoint> points) => 
            Points = points;
    }
}