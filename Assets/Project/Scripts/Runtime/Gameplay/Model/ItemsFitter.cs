using System;
using GardensBattle.Runtime.Gameplay.Model.Enums;
using GardensBattle.Runtime.Gameplay.Model.GardenStructure;
using GardensBattle.Runtime.Gameplay.Model.Shapes;
using Zenject;

namespace GardensBattle.Runtime.Gameplay.Model
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

        public bool TryFitItem(ItemName item, Point2D position, RotationAngle angle)
        {
            var shapePoints = shapesData
                .GetShape(item)
                .GetPoints(angle);
            
            foreach (var itemShapePoint in shapePoints)
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