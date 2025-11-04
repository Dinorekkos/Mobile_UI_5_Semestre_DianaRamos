using System.Collections.Generic;
using UnityEngine;

namespace SonocCardsSystem
{
    public class CardsIncventory : UIWindow
    {
        [Header("Cards Inventory UI")] [SerializeField]
        private GameObject cardPrefab;

        [SerializeField] private GameObject container;
        private List<CardUI> cardsInInventoryUI = new List<CardUI>();

        public void SetUpCardsInInventory(List<CardRuntime> cardsInInventory)
        {

            foreach (var cardRuntime in cardsInInventory)
            {
                GameObject go = Instantiate(cardPrefab, container.transform);
                CardUI cardUI = go.GetComponent<CardUI>();
                cardUI.SetupCardUI(cardRuntime);
                cardsInInventoryUI.Add(cardUI);
            }

        }
    }
}