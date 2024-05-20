using UnityEngine;

namespace GardensBattle.Runtime.Gameplay.Presenters.CellCreating
{
    [CreateAssetMenu(fileName = nameof(CellFactoryData), menuName = nameof(GardensBattle) + "/" + nameof(CellFactoryData),
        order = 0)]
    public class CellFactoryData : ScriptableObject
    {
        [SerializeField] private GameObject cellPrefab;

        public GameObject CellPrefab => cellPrefab;
    }
}