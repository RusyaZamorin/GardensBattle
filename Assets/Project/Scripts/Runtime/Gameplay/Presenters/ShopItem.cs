using System;
using GardensBattle.Runtime.Gameplay.Model.Enums;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GardensBattle.Runtime.Gameplay.Presenters
{
    public class ShopItem : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private ItemName item;

        public ItemName Item => item;
        
        public event Action<ShopItem> OnClickDown;
        
        public void Setup(ItemName itemName)
        {
            item = itemName;
        }

        public void OnPointerDown(PointerEventData eventData) => 
            OnClickDown?.Invoke(this);
    }
}