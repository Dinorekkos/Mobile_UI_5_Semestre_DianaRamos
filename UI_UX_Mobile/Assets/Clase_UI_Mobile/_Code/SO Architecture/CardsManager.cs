using System.Collections.Generic;
using Dino.UtilityTools.Singleton;
using NaughtyAttributes;
using UnityEngine;

public class CardsManager : Singleton<CardsManager>
{
    [Header("Cards Manager")]
    [SerializeField] private List<CardDataSO> cardDatas;
    
    [Header("Inventory")]
    [ReadOnly] public List <CardRuntime> CardsInventory = new List<CardRuntime>();
    
    
    
    private void Start()
    {
    }
    
    
    
    private CardDataSO GetCardDataByID(string cardId)
    {
        return cardDatas.Find(cardDataSo => cardDataSo.ID == cardId);
    }
    
    private void AddCardToInventory(CardDataSO cardDataSo)
    {
        CardRuntime newCard = CreateCard(cardDataSo);
        CardsInventory.Add(newCard);
    }

    private CardRuntime CreateCard(CardDataSO cardDataSo)
    {
        CardRuntime newCard = new CardRuntime(
            cardDataSo.CardName,
            cardDataSo.Description,
            cardDataSo.CardType
        );
        return newCard;
    }


    #region Test Create Dino Card

    [Button]
    private void TestCreateDinoCard()
    {
        CardDataSO cardDataSo = GetCardDataByID("dino");
        AddCardToInventory(cardDataSo);
        // UIManager.Instance.GetUIWindow()
        Debug.Log($"Card {cardDataSo.CardName} added to inventory.");
    }

    #endregion
    
    
}

