using GardensBattle.Runtime.Gameplay.Shapes;
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

        public override void InstallBindings()
        {
            Container.BindInstance(shapesData).AsSingle();
        }
    }
}