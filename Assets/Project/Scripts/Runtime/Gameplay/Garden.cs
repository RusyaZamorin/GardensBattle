using System.Collections.Generic;
using GardensBattle.Runtime.Gameplay.GardenBeds;

namespace GardensBattle.Runtime.Gameplay
{
    public class Garden
    {
        private Cell[,] cells = new Cell[GameplayConstants.GardenLinesCount, GameplayConstants.GardenColumnsCount];
        
        public List<GardenBed> Beds { get; }
        public List<PlacedItem> Items { get; }
    }
}