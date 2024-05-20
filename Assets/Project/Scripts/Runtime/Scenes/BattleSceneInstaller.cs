using GardensBattle.Runtime.Gameplay.Presenters;
using UnityEngine;
using Zenject;

namespace GardensBattle.Runtime.Scenes
{
    public class BattleSceneInstaller : MonoInstaller
    {
        [SerializeField] private GardenPresenter garden;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GardenPresenter>().FromInstance(garden).AsSingle();
        }
    }
}