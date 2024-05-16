using System;
using GardensBattle.Runtime.Gameplay.Enums;

namespace GardensBattle.Runtime.Gameplay.GardenStructure
{
    [Serializable]
    public class PlacedItem
    {
        public ItemName ItemName;
        public Point2D Position;

        public PlacedItem(ItemName itemName, Point2D position)
        {
            ItemName = itemName;
            Position = position;
        }
    }
}