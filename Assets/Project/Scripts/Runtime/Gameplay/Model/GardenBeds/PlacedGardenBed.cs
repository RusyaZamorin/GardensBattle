using System;
using GardensBattle.Runtime.Gameplay.Model.Enums;

namespace GardensBattle.Runtime.Gameplay.Model.GardenBeds
{
    [Serializable]
    public class PlacedGardenBed
    {
        public GardenBedName Name;
        public Point2D Position;
    }
}