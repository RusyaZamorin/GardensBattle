using GardensBattle.Runtime.Gameplay.GardenBeds;

namespace GardensBattle.Runtime.Gameplay.GardenStructure
{
    public class Cell
    {
        public bool IsEmpty => PlacedGardenBed == null && PlacedItem == null;
        public bool ContainsGardenBed => PlacedGardenBed != null;
        public bool ContainsItem => PlacedItem != null;
        
        internal PlacedItem PlacedItem { get; set; }
        internal PlacedGardenBed PlacedGardenBed { get; set; }

        public void ClearItem() => PlacedItem = null;
        public void ClearGardenBed() => PlacedGardenBed = null;

        public PlacedItem GetItem() => PlacedItem;
        public PlacedGardenBed GetGardenBed() => PlacedGardenBed;
    }
}