using GardensBattle.Runtime.Gameplay.Model;
using GardensBattle.Runtime.Gameplay.Model.GardenStructure;
using GardensBattle.Runtime.Gameplay.Model.Shapes;
using GardensBattle.Runtime.Gameplay.Presenters.CellCreating;
using GardensBattle.Runtime.Services;
using UnityEngine;
using Zenject;

namespace GardensBattle.Runtime
{
    [CreateAssetMenu(fileName = nameof(ProjectInstaller),
        menuName = nameof(GardensBattle) + "/" + nameof(ProjectInstaller),
        order = 0)]
    public class ProjectInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ShapesData shapesData;
        [SerializeField] private CellFactoryData cellFactoryData;
        
        public override void InstallBindings()
        {
            Container.BindInstance(shapesData).AsSingle();
            Container.BindInstance(cellFactoryData).AsSingle();

            Container.BindInterfacesAndSelfTo<Garden>().AsSingle();
            Container.Bind<CellFactory>().AsSingle();
            Container.Bind<ItemsFitter>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<DragAndDropService>().AsSingle();
        }
    }
}