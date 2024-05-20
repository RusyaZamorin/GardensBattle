using System;
using GardensBattle.Runtime.Gameplay.Model.Enums;
using GardensBattle.Runtime.Gameplay.Model.GardenBeds;

namespace GardensBattle.Runtime.Gameplay.Model.GardenStructure
{
    public class Cell
    {
        private PlacedItem item;

        public Point2D Position { get; private set; }
        public bool IsEmpty => PlacedGardenBed == null && PlacedItem == null;
        public bool ContainsGardenBed => PlacedGardenBed != null;
        public bool ContainsItem => PlacedItem != null;

        internal PlacedItem PlacedItem
        {
            get => item;
            set
            {
                item = value;
                OnItemAdded?.Invoke(item.ItemName);
            }
        }


        internal PlacedGardenBed PlacedGardenBed { get; set; }

        public event Action<ItemName> OnItemAdded;
        public event Action<ItemName> OnItemRemoved;

        
        public Cell(Point2D position) =>
            Position = position;

        public void ClearItem()
        {
            OnItemRemoved?.Invoke(item.ItemName);
            PlacedItem = null;
        }

        public void ClearGardenBed() => PlacedGardenBed = null;
    }
}