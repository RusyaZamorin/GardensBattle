using System.Collections.Generic;
using System.Linq;
using GardensBattle.Runtime.Gameplay.Model.Enums;
using GardensBattle.Runtime.Gameplay.Model.GardenBeds;
using GardensBattle.Runtime.Gameplay.Model.Shapes;
using Zenject;

namespace GardensBattle.Runtime.Gameplay.Model.GardenStructure
{
    public class Garden : IInitializable
    {
        private Cell[,] cells;
        private ShapesData shapesData;

        public List<PlacedGardenBed> GardenBeds { get; private set; } = new();
        public List<PlacedItem> Items { get; } = new();

        public Cell[,] Cells => cells;

        [Inject]
        public Garden(ShapesData shapesData)
        {
            this.shapesData = shapesData;
        }

        public void Initialize()
        {
            cells = new Cell[GameplayConstants.GardenLinesCount, GameplayConstants.GardenColumnsCount];
            
            for (var i = 0; i < GameplayConstants.GardenLinesCount; i++)
            for (var j = 0; j < GameplayConstants.GardenColumnsCount; j++)
                cells[i, j] = new Cell(new Point2D(j, i));
        }

        public bool CellContainsItem(Point2D position) =>
            cells[position.X, position.Y].ContainsItem;

        public bool CellContainsGardenBed(Point2D position) => 
            cells[position.X, position.Y].ContainsGardenBed;

        internal void AddItem(ItemName itemName, Point2D position)
        {
            if (!InCellMatrixRange(position))
                return;

            var placedItem = new PlacedItem(itemName, position);
            Items.Add(placedItem);
            
            var itemShape = shapesData.GetShape(itemName);
            
            foreach (var cellPosition in itemShape.GetPoints().Select(itemShapePoint => position + itemShapePoint))
                cells[cellPosition.X, cellPosition.Y].PlacedItem = placedItem;
        }

        internal void RemoveItem(PlacedItem placedItem)
        {
            Items.Remove(placedItem);
            var itemShape = shapesData.GetShape(placedItem.ItemName);
            foreach (var itemShapePoint in itemShape.GetPoints())
            {
                var itemPoint = itemShapePoint + placedItem.Position;
                cells[itemPoint.X, itemPoint.Y].ClearItem();
            }
        }

        private static bool InCellMatrixRange(Point2D position) =>
            position.X <= GameplayConstants.GardenLinesCount || position.Y <= GameplayConstants.GardenColumnsCount;
    }
}