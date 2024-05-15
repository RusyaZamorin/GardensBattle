using AYellowpaper.SerializedCollections;
using GardensBattle.Runtime.Gameplay.Enums;
using UnityEngine;

namespace GardensBattle.Runtime.Gameplay.Shapes
{
    [CreateAssetMenu(fileName = nameof(ShapesData), menuName = nameof(GardensBattle) + "/" + nameof(ShapesData), order = 0)]
    public class ShapesData : ScriptableObject
    {
        public SerializedDictionary<ShapeName, Shape> Shapes;
    }
}