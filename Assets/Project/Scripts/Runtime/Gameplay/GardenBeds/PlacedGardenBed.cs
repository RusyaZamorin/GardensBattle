using System;
using GardensBattle.Runtime.Gameplay.Enums;

namespace GardensBattle.Runtime.Gameplay.GardenBeds
{
    [Serializable]
    public class PlacedGardenBed
    {
        public GardenBedName Name;
        public Point2D Position;
    }
}