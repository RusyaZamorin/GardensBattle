using GardensBattle.Runtime.Gameplay.Model.GardenStructure;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GardensBattle.Runtime.Gameplay.Presenters
{
    public class CellPresenter : MonoBehaviour, IPointerClickHandler
    {
        private Cell cell;

        public Cell Cell => cell;
        
        public void Setup(Cell cell)
        {
            this.cell = cell;
            
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            
        }
    }
}