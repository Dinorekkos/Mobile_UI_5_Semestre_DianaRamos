using System.Collections.Generic;
using UnityEngine;

namespace SonocCardsSystem
{
    public class CardsInventoryUI : UIWindow
    {
        [Header("Cards Inventory UI")] 
        [SerializeField] private GameObject cardPrefab;
        [SerializeField] private GameObject container;
        
        private List<CardUI> cardsInInventoryUI = new List<CardUI>();

        public void SetUpCardsInInventory(List<CardRuntime> cardsInInventory)
        {
            // Clear existing UI elements
            foreach (var cardUI in cardsInInventoryUI)
            {
                Destroy(cardUI.gameObject);
            }
            cardsInInventoryUI.Clear();
            
            // Create new UI elements for each card in the inventory
            foreach (var cardRuntime in cardsInInventory)
            {
                GameObject go = Instantiate(cardPrefab, container.transform);
                CardUI cardUI = go.GetComponent<CardUI>();
                cardUI.SetupCardUI(cardRuntime);
                cardUI.SetUnlocked(cardRuntime.IsUnlocked);
                cardsInInventoryUI.Add(cardUI);
            }

        }
    }
}