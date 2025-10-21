using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class CardsPanelUI : UIWindow
{
    [Header("Cards Panel UI")]
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private GameObject container;
    
    [SerializeField, ReadOnly] private List <CardUI> cardUIs = new List<CardUI>();
    
    
    public void AddCard(CardRuntime cardRuntime)
    {
        if(cardUIs.Count >= 4) return;
        GameObject go = Instantiate(cardPrefab, container.transform);
        CardUI cardUI = go.GetComponent<CardUI>();
        cardUI.SetupCardUI(cardRuntime);
        cardUIs.Add(cardUI);
    }
}
