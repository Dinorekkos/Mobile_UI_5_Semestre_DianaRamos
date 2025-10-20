using System.Collections.Generic;
using Dino.UtilityTools.Singleton;
using UnityEngine;

public class CardsManager : Singleton<CardsManager>
{
    [SerializeField] private List<CardData> cardDatas;
    public List<CardData> CardDatas => cardDatas;

}
