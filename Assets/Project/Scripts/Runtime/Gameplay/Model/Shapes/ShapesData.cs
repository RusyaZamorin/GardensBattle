using System;
using AYellowpaper.SerializedCollections;
using GardensBattle.Runtime.Gameplay.Model.Enums;
using UnityEngine;

namespace GardensBattle.Runtime.Gameplay.Model.Shapes
{
    [CreateAssetMenu(fileName = nameof(ShapesData), menuName = nameof(GardensBattle) + "/" + nameof(ShapesData),
        order = 0)]
    public class ShapesData : ScriptableObject
    {
        [SerializeField] private SerializedDictionary<ShapeName, Shape> shapes;
        [SerializeField] private SerializedDictionary<ItemName, ShapeName> itemShapes;
        [SerializeField] private SerializedDictionary<GardenBedName, ShapeName> gardenBedShapes;
        
        public Shape GetShape(GardenBedName placedGardenBed)
        {
            if (gardenBedShapes.TryGetValue(placedGardenBed, out var shapeName))
                return GetShape(shapeName);

            throw new Exception($"Shape type for garden bed: {placedGardenBed} not fond");
        }
        
        public Shape GetShape(ItemName item)
        {
            if (itemShapes.TryGetValue(item, out var shapeName))
                return GetShape(shapeName);

            throw new Exception($"Shape type for item: {item} not fond");
        }

        public Shape GetShape(ShapeName name)
        {
            if (shapes.TryGetValue(name, out var shape))
            {
                return shape;
            }

            throw new Exception($"Shape data for name: {name} not fond");
        }
    }
}