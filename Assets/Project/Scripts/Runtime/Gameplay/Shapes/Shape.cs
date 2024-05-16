using System;
using System.Collections.Generic;
using Array2DEditor;
using UnityEngine;

namespace GardensBattle.Runtime.Gameplay.Shapes
{
    [Serializable]
    public class Shape
    {
        [SerializeField] private Array2DBool Matrix;

        private List<Point2D> points;

        public List<Point2D> Points
        {
            get
            {
                points ??= GetPoints();
                return points;
            }
        }

        private List<Point2D> GetPoints()
        {
            var points = new List<Point2D>();
            var size = Matrix.GridSize;
            
            for (var y = 0; y < size.y; y++)
            for (var x = 0; x < size.x; x++)
                if (Matrix.GetCell(x, y))
                    points.Add(new Point2D(x, y));

            return points;
        }
    }
}