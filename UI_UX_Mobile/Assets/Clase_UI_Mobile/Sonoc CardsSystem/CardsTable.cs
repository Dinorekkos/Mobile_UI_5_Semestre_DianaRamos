using System.Collections.Generic;
using UnityEngine;

public class CardsTable : UIWindow
{
    [SerializeField] private List<CardUI> cardsOnTableUI = new List<CardUI>();
    
    
    public void SetUpCardsOnTable(List<CardRuntime> cardsOnTable)
    {
        for (int i = 0; i < cardsOnTableUI.Count; i++)
        { 
            cardsOnTableUI[i].SetupCardUI(cardsOnTable[i]);
        }
    }
}
