using System;
using System.Collections.Generic;
using Array2DEditor;
using GardensBattle.Runtime.Gameplay.Model.Enums;
using UnityEngine;

namespace GardensBattle.Runtime.Gameplay.Model.Shapes
{
    [Serializable]
    public class Shape
    {
        [SerializeField] private Array2DBool shape;
        private bool[,] matrix;
        
        public List<Point2D> GetPoints(RotationAngle rotationAngle = RotationAngle.Degree0)
        {
            matrix = shape.GetCells();
            Rotate(rotationAngle);
            
            var points = new List<Point2D>();
            var size = shape.GridSize;
            var halfSize = new Point2D(size.x / 2, size.y / 2);

            for (var y = 0; y < size.y; y++)
            for (var x = 0; x < size.x; x++)
                if (matrix[y, x])
                    points.Add(new Point2D(x - halfSize.X, -(y - halfSize.Y)));

            return points;
        }


        private void Rotate(RotationAngle rotationAngle)
        {
            var countOfRotate  = rotationAngle switch
            {
                RotationAngle.Degree0 => 0,
                RotationAngle.Degree90 => 1,
                RotationAngle.Degree180 => 2,
                RotationAngle.Degree270 => 3,
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