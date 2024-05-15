using GardensBattle.Runtime.Gameplay.GardenBeds;
using GardensBattle.Runtime.Gameplay.Items;

namespace GardensBattle.Runtime.Gameplay
{
    public class Cell
    {
        public Item Item { get; } = null;
        public GardenBed GardenBed { get; } = null;

        public bool IsEmpty => GardenBed == null && Item == null;
        public bool ContainsGarden => GardenBed != null;
        public bool ContainsItem => Item != null;
    }
}