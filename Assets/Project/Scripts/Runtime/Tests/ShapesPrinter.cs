using System.Collections.Generic;
using GardensBattle.Runtime.Gameplay.Enums;
using GardensBattle.Runtime.Gameplay.Shapes;
using UnityEngine;
using Zenject;

namespace GardensBattle.Runtime.Tests
{
    public class ShapesPrinter : MonoBehaviour
    {
        [SerializeField] private GameObject squarePrefab;
        [SerializeField] private ShapeName shapeType;
        [SerializeField] private ShapeRotation shapeRotation;
        
        private ShapesData shapesData;
        private List<GameObject> shapeParts = new();
        
        [Inject]
        private void Construct(ShapesData shapesData)
        {
            this.shapesData = shapesData;
        }

        [ContextMenu(nameof(CreateShape))]
        public void CreateShape()
        {
            DeleteShape();
            
            var shape = shapesData.GetShape(shapeType);
            foreach (var shapePoint in shape.GetPoints(shapeRotation))
            {
                var instantiate = Instantiate(squarePrefab, new Vector3(shapePoint.X, shapePoint.Y, 0f), Quaternion.identity);
                shapeParts.Add(instantiate);
            }
        }

        [ContextMenu(nameof(DeleteShape))]
        public void DeleteShape()
        {
            foreach (var shapePart in shapeParts) 
                Destroy(shapePart);
            shapeParts.Clear();
        }
    }
}