using System.Collections.Generic;
using GardensBattle.Runtime.Gameplay.Model.GardenStructure;
using GardensBattle.Runtime.Gameplay.Presenters.CellCreating;
using UnityEngine;
using Zenject;

namespace GardensBattle.Runtime.Gameplay.Presenters
{
    public class GardenPresenter : MonoBehaviour, IInitializable
    {
        private Garden garden;
        private CellFactory cellFactory;
        private List<CellPresenter> cells = new();

        public List<CellPresenter> Cells => cells;

        [Inject]
        private void Construct(
            Garden garden,
            CellFactory cellFactory)
        {
            this.cellFactory = cellFactory;
            this.garden = garden;
        }

        public async void Initialize()
        {
            foreach (var cell in garden.Cells)
                cells.Add(await cellFactory.Create(transform, cell));
        }
    }
}