using System.Collections.Generic;
using UnityEngine;

public class CardsTable : UIWindow
{
    [Header("Cards Table UI")]
    [SerializeField] private List<CardUI> cardsOnTableUI = new List<CardUI>();
    public void SetUpCardsOnTable(List<CardRuntime> cardsOnTable)
    {
        // Ensure the number of UI elements matches the number of cards on the table 
        // Only 3 cards on table for now
        if (cardsOnTable.Count != cardsOnTableUI.Count) return;
        for (int i = 0; i < cardsOnTableUI.Count; i++)
        { 
            cardsOnTableUI[i].SetupCardUI(cardsOnTable[i]);
        }
    }
}
