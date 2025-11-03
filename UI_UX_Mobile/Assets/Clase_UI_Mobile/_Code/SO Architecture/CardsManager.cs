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
        LoadCardsInventory();
    }
    
    public CardRuntime SelectRandomCardFromInventory()
    {
        if (CardsInventory.Count == 0) return null;
        int randomIndex = Random.Range(0, CardsInventory.Count);
        return CardsInventory[randomIndex];
    }
    
    public CardRuntime SelectCardFromInventory(string cardId)
    {
        return CardsInventory.Find(card => card.Id == cardId);
    }
    
    private CardData_SO GetCardDataByID(string cardId)
    {
        return cardDatas.Find(cardDataSo => cardDataSo.ID == cardId);
    }
    
    private void AddCardToInventory(CardData_SO cardDataSo)
    {
        CardRuntime newCard = CreateCard(cardDataSo);
        CardsInventory.Add(newCard);
        ShowCardInUI(newCard.Id);
    }

    private CardRuntime CreateCard(CardData_SO cardDataSo)
    {
        CardRuntime newCard = new CardRuntime(
            cardDataSo,
            cardDataSo.ID,
            cardDataSo.CardName,
            cardDataSo.CardType,
            true
        );
        return newCard;
    }
    
    private void ShowCardInUI(string cardId)
    {
        CardsPanelUI cardsPanelUI = UIManager.Instance.GetUIWindow(WindowsIDs.CardsPanel) as CardsPanelUI;
        if (cardsPanelUI == null) return;
        cardsPanelUI.AddCard(SelectCardFromInventory(cardId));
    }


    #region Save/Load Inventory

    [Button]
    public void SaveCardsInventory()
    {

        List<CardRuntime> cards = CardsInventory;
        
        //Create json string from cards list
        string json = JsonHelper.ToJson(cards.ToArray(), true);
        
        //create json file in persistent data path
        string path = Application.persistentDataPath + "/cardsInventory.json";
        System.IO.File.WriteAllText(path, json);
        
        Debug.Log("Cards Inventory saved to: " + path);
        

    }
    
    public void LoadCardsInventory()
    {
        string path = Application.persistentDataPath + "/cardsInventory.json";
        if (!System.IO.File.Exists(path))
        {
            Debug.LogWarning("No saved Cards Inventory found at: " + path);
            return;
        }
        
        string json = System.IO.File.ReadAllText(path);
        CardRuntime[] cards = JsonHelper.FromJson<CardRuntime>(json);
        
        CardsInventory = new List<CardRuntime>(cards);
        
        Debug.Log("Cards Inventory loaded from: " + path);
    }

    #endregion
    

    #region Test Create Dino Card

    [Button]
    private void TestCreateDinoCard()
    {
        CardData_SO cardDataSo = GetCardDataByID("dino");
        AddCardToInventory(cardDataSo);
    }

   

    [Button]
    private void TestCreateSonocCard()
    {
        CardData_SO cardDataSo = GetCardDataByID("sonoc");
        AddCardToInventory(cardDataSo);
    }
    
    
    #endregion
    
    
}

