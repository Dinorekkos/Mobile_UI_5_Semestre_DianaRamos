using System.Collections.Generic;
using Dino.UtilityTools.Singleton;
using UnityEngine;

public class CardsManager : Singleton<CardsManager>
{
    [Header("Cards Manager")]
    [SerializeField] private List<CardDataSO> cardDatas;
    
    public List <CardRuntime> CardsInventory = new List<CardRuntime>();
    
    
    
}

