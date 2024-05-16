using System;
using GardensBattle.Runtime.Gameplay.Enums;
using GardensBattle.Runtime.Gameplay.GardenStructure;
using GardensBattle.Runtime.Gameplay.Shapes;
using Zenject;

namespace GardensBattle.Runtime.Gameplay
{
    public class ItemsFitter
    {
        private Garden garden;
        private ShapesData shapesData;

        public event Action<ItemName, Point2D> OnFitted;
        public event Action<ItemName, Point2D> OnFitFailed;

        [Inject]
        public ItemsFitter(ShapesData shapesData, Garden garden)
        {
            this.shapesData = shapesData;
            this.garden = garden;
        }

        public bool TryFitItem(ItemName item, Point2D position)
        {
            var itemShape = shapesData.GetShape(item);
            foreach (var itemShapePoint in itemShape.Points)
            {
                var cellPosition = itemShapePoint + position;
                if (garden.CellContainsItem(cellPosition))
                {
                    OnFitFailed?.Invoke(item, position);
                    return false;
                }
            }
            
            garden.AddItem(item, position);
            OnFitted?.Invoke(item, position);
            return true;
        }
    }
}