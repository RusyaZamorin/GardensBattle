using System;
using System.Collections.Generic;
using GardensBattle.Runtime.Gameplay.Model.GardenBeds;

namespace GardensBattle.Runtime.Gameplay.Model.GardenStructure
{
    [Serializable]
    public class GardenData
    {
        public List<PlacedGardenBed> GardenBeds { get; private set; } = new();
        public List<PlacedItem> Items { get; private set; } = new();
        
        public GardenData(Garden garden)
        {
            Items = garden.Items;
            GardenBeds = garden.GardenBeds;
        }
        
    }
}