using System.Collections.Generic;
using GardensBattle.Runtime.Gameplay.Model.Enums;
using GardensBattle.Runtime.Gameplay.Model.Shapes;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace GardensBattle.Runtime.Tests
{
    public class ShapesPrinter : MonoBehaviour
    {
        [SerializeField] private GameObject squarePrefab;
        [SerializeField] private ShapeName shapeType;
        [FormerlySerializedAs("shapeRotation")] [SerializeField] private RotationAngle RotationAngle;
        
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
            foreach (var shapePoint in shape.GetPoints(RotationAngle))
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