using System;

[Serializable]
public class CardRuntime
{
    //Runtime representation of a card
    public CardData_SO CardData_SO;
    public string Id;
    public string CardName;
    public CardType CardType;
    public bool IsUnlocked = false;
    
    
    public CardRuntime(CardData_SO cardDataSo,string id,string cardName, CardType cardType, bool isUnlocked)
    {
        CardData_SO = cardDataSo;
        CardName = cardName;
        CardType = cardType;
        IsUnlocked = isUnlocked;
        Id = id;
    }
}