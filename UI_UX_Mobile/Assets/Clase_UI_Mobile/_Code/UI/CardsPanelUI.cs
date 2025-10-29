using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class CardsPanelUI : UIWindow
{
    [Header("Cards Panel UI")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject container;
    
    [SerializeField, ReadOnly] private List <Card> cards = new List<Card>();
    
    
    public void AddCard(CardRuntime cardRuntime)
    {
        if(cards.Count >= 4) return;
        GameObject go = Instantiate(cardPrefab, container.transform);
        Card card = go.GetComponent<Card>();
        card.SetupCardUI(cardRuntime);
        cards.Add(card);
    }
}
