using Cysharp.Threading.Tasks;
using GardensBattle.Runtime.Gameplay.Model.GardenStructure;
using UnityEngine;
using Zenject;

namespace GardensBattle.Runtime.Gameplay.Presenters.CellCreating
{
    public class CellFactory
    {
        private CellFactoryData data;

        [Inject]
        public CellFactory(CellFactoryData data)
        {
            this.data = data;
        }

        public async UniTask<CellPresenter> Create(Transform parent, Cell cell)
        {
            var cellGameObject = Object.Instantiate(data.CellPrefab, parent);
            cellGameObject.transform.localPosition = cell.Position.ToVector2();

            var cellPresenter = cellGameObject.GetComponent<CellPresenter>();
            cellPresenter.Setup(cell);
            return cellPresenter;
        }
    }
}