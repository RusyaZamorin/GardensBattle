using System;
using UnityEngine;

namespace GardensBattle.Runtime.Gameplay.Model
{
    [Serializable]
    public struct Point2D
    {
        public int X;
        public int Y;

        public Point2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Vector2 ToVector2() => new(X, Y);

        public static Point2D operator+ (Point2D point1, Point2D point2) => 
            new(point1.X + point2.X, point1.Y + point2.Y);

        public static Point2D operator- (Point2D point1, Point2D point2) => 
            new(point1.X - point2.X, point1.Y - point2.Y);
    }
}