using System;
using System.Collections.Generic;
using Array2DEditor;
using UnityEngine;

namespace GardensBattle.Runtime.Gameplay.Shapes
{
    [Serializable]
    public class Shape
    {
        [SerializeField] private Array2DBool shape;
        private bool[,] matrix;
        
        public List<Point2D> GetPoints(ShapeRotation rotation = ShapeRotation.Degree0)
        {
            matrix = shape.GetCells();
            Rotate(rotation);
            
            var points = new List<Point2D>();
            var size = shape.GridSize;
            var halfSize = new Point2D(size.x / 2, size.y / 2);

            for (var y = 0; y < size.y; y++)
            for (var x = 0; x < size.x; x++)
                if (matrix[y, x])
                    points.Add(new Point2D(x - halfSize.X, -(y - halfSize.Y)));

            return points;
        }


        private void Rotate(ShapeRotation rotation)
        {
            var countOfRotate  = rotation switch
            {
                ShapeRotation.Degree0 => 0,
                ShapeRotation.Degree90 => 1,
                ShapeRotation.Degree180 => 2,
                ShapeRotation.Degree270 => 3,
            };

            for (var i = 0; i < countOfRotate; i++) 
                RotateClockwise();
        }
        
        private void RotateClockwise()
        {
            var size = shape.GridSize.x;
            for (var i = 0; i < size / 2; i++)
            for (var j = i; j < size - i - 1; j++)
            {
                var temp = matrix[i, j];
                matrix[i, j] =  matrix[size - 1 - j, i];
                matrix[size - 1 - j, i] = matrix[size - 1 - i, size - 1 - j];
                matrix[size - 1 - i, size - 1 - j] = matrix[j, size - 1 - i];
                matrix[j, size - 1 - i] = temp;
            }
        }
    }
}