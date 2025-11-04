using System;
using System.Collections.Generic;
using System.Linq;
using Dino.UtilityTools.Extensions;
using Dino.UtilityTools.Singleton;
using UnityEngine;
using NaughtyAttributes;

namespace SonocCardsSystem
{
    public class CardsManagerSonoc : Singleton<CardsManagerSonoc>
    {
        [Header("Cards Manager")] [SerializeField]
        private List<CardData_SO> cardDatas;

        [Header("Inventory")] [ReadOnly] public List<CardRuntime> CardsInventory = new List<CardRuntime>();

        [Header("Unlocked and Locked Cards")] [ReadOnly]
        public List<CardRuntime> UnlockedCards = new List<CardRuntime>();

        [ReadOnly] public List<CardRuntime> LockedCards = new List<CardRuntime>();

        CardRuntime selectedMayorCard;

        private void Start()
        {

            #region Initialization Process

            //First Create All Cards to the Inventory
            //Cards are LOCKED by DEFAULT
            CreateAllCards();

            //Then Find Unlocked Cards from Save and set them to UNLOCKED true
            //Here we update the CardsInventory list and also fill the UnlockedCards list
            FindUnlockedCardsFromSave();

            //Update the LockedCards list
            //From this list we are going to select random locked cards to unlock
            UpdateLockedCardsList();

            // Select a random Mayor locked card
            selectedMayorCard = SelectRandomMayorLockedCard();

            //Update Cards in the Table UI based on the selected Mayor card
            UpdateCardsInTable();

            #endregion


        }

        #region Initialization Methods

        private void CreateAllCards()
        {
            foreach (var cardData in cardDatas)
            {
                CardRuntime newCard = new CardRuntime(
                    cardData,
                    cardData.ID,
                    cardData.CardName,
                    cardData.CardType,
                    // All cards are locked by default
                    false
                );
                CardsInventory.Add(newCard);
            }
        }

        private void FindUnlockedCardsFromSave()
        {
            string path = Application.persistentDataPath + "/cardsInventory.json";
            if (!System.IO.File.Exists(path))
            {
                Debug.LogWarning("No saved Cards Inventory found at: " + path);
                return;
            }

            string json = System.IO.File.ReadAllText(path);
            CardRuntime[] cards = JsonHelper.FromJson<CardRuntime>(json);

            foreach (var cardsFromSave in cards)
            {
                if (cardsFromSave.IsUnlocked)
                {
                    //Find the card in the CardsInventory and set it to Unlocked
                    CardRuntime cardInInventory = CardsInventory.Find(card => card.Id == cardsFromSave.Id);
                    if (cardInInventory != null)
                    {
                        //Set card from inventory to Unlocked
                        cardInInventory.IsUnlocked = true;
                        //Add to UnlockedCards list
                        UnlockedCards.Add(cardInInventory);
                    }
                }
            }
        }

        private void UpdateLockedCardsList()
        {
            LockedCards.Clear();
            foreach (var card in CardsInventory)
            {
                if (!card.IsUnlocked)
                {
                    LockedCards.Add(card);
                }
            }
        }

        private CardRuntime SelectRandomMayorLockedCard()
        {
            List<CardRuntime> mayorLockedCards = LockedCards.FindAll(card => card.CardData_SO as CardMayorSO);
            if (mayorLockedCards.Count == 0)
            {
                Debug.Log("No locked Mayor cards available.");
                return null;
            }

            //Select a random Mayor locked card
            CardRuntime selectedCard = mayorLockedCards[UnityEngine.Random.Range(0, mayorLockedCards.Count)];

            Debug.Log("Selected Mayor Card: ".SetColor(ColorDebug.Red) + selectedCard.CardName);
            return selectedCard;
        }

        private void UpdateCardsInTable()
        {
            //Get CardsTable UI
            CardsTable cardsTable = UIManager.Instance.GetUIWindow(WindowsIDs.CardsTable) as CardsTable;
            if (cardsTable == null) return;

            //Get related cards from the selected Mayor card
            CardMayorSO mayorSo = selectedMayorCard.CardData_SO as CardMayorSO;
            if (mayorSo == null) return;

            //Find related CardRuntime from CardsInventory
            List<CardRuntime> relatedCards = new List<CardRuntime>();
            foreach (var relatedCardData in mayorSo.RelatedCards)
            {
                CardRuntime relatedCardRuntime = CardsInventory.Find(card => card.CardData_SO == relatedCardData);
                if (relatedCardRuntime != null)
                {
                    relatedCards.Add(relatedCardRuntime);
                }
            }

            //Set up cards on the table
            cardsTable.SetUpCardsOnTable(relatedCards);
        }

        #endregion


        #region Save Inventory

        [Button]
        public void SaveCardsInventory()
        {
            List<CardRuntime> cards = CardsInventory;

            string json = JsonHelper.ToJson(cards.ToArray(), true);
            string path = Application.persistentDataPath + "/cardsInventory.json";
            System.IO.File.WriteAllText(path, json);
            Debug.Log("Cards Inventory saved to: " + path);
        }

        #endregion


        #region Gameplay Methods


        public void SetCardAsUnlocked(CardRuntime card)
        {
            if (card == null) return;

            //Set card as unlocked
            card.IsUnlocked = true;

            //Add to UnlockedCards list
            if (!UnlockedCards.Contains(card))
            {
                UnlockedCards.Add(card);
            }

            //Remove from LockedCards list
            if (LockedCards.Contains(card))
            {
                LockedCards.Remove(card);
            }

            Debug.Log("Card Unlocked: ".SetColor(ColorDebug.Green) + card.CardName);
        }




        #endregion

    }
}