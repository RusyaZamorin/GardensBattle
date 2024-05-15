using System.Collections.Generic;
using GardensBattle.Runtime.Gameplay.Items;

namespace GardensBattle.Runtime.Gameplay
{
    public class PlacedItem
    {
        public Item Item;
        public List<Cell> Cells;
        
        public PlacedItem(Item item, List<Cell> cells)
        {
            Item = item;
            Cells = cells;
        }
    }
}