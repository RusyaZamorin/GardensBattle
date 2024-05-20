using System;
using System.Collections.Generic;
using GardensBattle.Runtime.Gameplay.Model;
using GardensBattle.Runtime.Gameplay.Model.Enums;
using GardensBattle.Runtime.Gameplay.Presenters;
using GardensBattle.Runtime.Services;
using UnityEngine;
using Zenject;

namespace GardensBattle.Runtime.Tests
{
    public class FitItemDebug : MonoBehaviour
    {
        [SerializeField] private List<ShopItem> items;
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Transform shopAnchor;

        private DragAndDropService dragAndDropService;
        private ItemsFitter itemsFitter;
        private GardenPresenter garden;

        [Inject]
        private void Construct(
            DragAndDropService dragAndDropService,
            ItemsFitter itemsFitter,
            GardenPresenter garden)
        {
            this.garden = garden;
            this.itemsFitter = itemsFitter;
            this.dragAndDropService = dragAndDropService;
        }

        private void Awake()
        {
            items.ForEach(i => i.OnClickDown += ClickOnItem);
        }

        private void ClickOnItem(ShopItem item)
        {
            dragAndDropService.Attach(item.transform, () => FitItem(item));
        }

        private void Update() { }

        private void FitItem(ShopItem item)
        {
            var itemPosition = item.transform.position;

            var hit = Physics2D.Raycast(
                itemPosition, 
                Vector2.zero,
                100f,
                layerMask);

            if (hit.collider != null)
            {
                var hitObject = hit.collider.gameObject;
                var cell = hitObject.GetComponent<CellPresenter>();
                if (cell != null)
                {
                    item.transform.position = itemsFitter.TryFitItem(item.Item, cell.Cell.Position, RotationAngle.Degree0)
                        ? cell.transform.position + Vector3.back
                        : shopAnchor.position;
                }
            }
            else
                item.transform.position = shopAnchor.position;


        }
    }
}