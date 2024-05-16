using System.Collections.Generic;
using System.Linq;
using GardensBattle.Runtime.Gameplay.Enums;
using GardensBattle.Runtime.Gameplay.GardenBeds;
using GardensBattle.Runtime.Gameplay.Shapes;
using Zenject;

namespace GardensBattle.Runtime.Gameplay.GardenStructure
{
    public class Garden
    {
        private Cell[,] cells = new Cell[GameplayConstants.GardenLinesCount, GameplayConstants.GardenColumnsCount];
        private ShapesData shapesData;

        public List<PlacedGardenBed> GardenBeds { get; private set; } = new();
        public List<PlacedItem> Items { get; private set; } = new();

        public Cell[,] Cells => cells;
        
        [Inject]
        public Garden(ShapesData shapesData)
        {
            this.shapesData = shapesData;
        }

        public bool CellContainsGardenBed(Point2D position) => 
            cells[position.X, position.Y].ContainsGardenBed;

        public bool CellContainsItem(Point2D position) =>
            cells[position.X, position.Y].ContainsItem;

        internal void AddItem(ItemName itemName, Point2D position)
        {
            if (!InCellMatrixRange(position))
                return;

            var placedItem = new PlacedItem(itemName, position);
            Items.Add(placedItem);
            
            var itemShape = shapesData.GetShape(itemName);
            
            foreach (var cellPosition in itemShape.Points.Select(itemShapePoint => position + itemShapePoint))
                cells[cellPosition.X, cellPosition.Y].PlacedItem = placedItem;
        }

        internal void RemoveItem(PlacedItem placedItem)
        {
            Items.Remove(placedItem);
            var itemShape = shapesData.GetShape(placedItem.ItemName);
            foreach (var itemShapePoint in itemShape.Points)
            {
                var itemPoint = itemShapePoint + placedItem.Position;
                cells[itemPoint.X, itemPoint.Y].ClearItem();
            }
        }

        private static bool InCellMatrixRange(Point2D position) =>
            position.X >= GameplayConstants.GardenLinesCount || position.Y >= GameplayConstants.GardenColumnsCount;
    }
}