using System.Collections.Generic;
using Dino.UtilityTools.Singleton;
using NaughtyAttributes;
using UnityEngine;

public class CardsManager : Singleton<CardsManager>
{
    [Header("Cards Manager")]
    [SerializeField] private List<CardData_SO> cardDatas;
    
    [Header("Inventory")]
    [ReadOnly] public List <CardRuntime> CardsInventory = new List<CardRuntime>();
    
    
    
    private void Start()
    {
    }
    
    
    private CardData_SO GetCardDataByID(string cardId)
    {
        return cardDatas.Find(cardDataSo => cardDataSo.ID == cardId);
    }
    
    private void AddCardToInventory(CardData_SO cardDataSo)
    {
        CardRuntime newCard = CreateCard(cardDataSo);
        CardsInventory.Add(newCard);
    }

    private CardRuntime CreateCard(CardData_SO cardDataSo)
    {
        CardRuntime newCard = new CardRuntime(
            cardDataSo.ID,
            cardDataSo.CardName,
            cardDataSo.CardType,
            true
        );
        return newCard;
    }


    #region Test Create Dino Card

    [Button]
    private void TestCreateDinoCard()
    {
        CardData_SO cardDataSo = GetCardDataByID("dino");
        AddCardToInventory(cardDataSo);
        // UIManager.Instance.GetUIWindow()
        Debug.Log($"Card {cardDataSo.CardName} added to inventory.");
    }

    [Button]
    private void TestCreateSonocCard()
    {
        CardData_SO cardDataSo = GetCardDataByID("sonoc");
        AddCardToInventory(cardDataSo);
    }
    
    
    #endregion
    
    
}

