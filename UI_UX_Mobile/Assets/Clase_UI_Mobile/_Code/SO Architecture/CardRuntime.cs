using System;

[Serializable]
public class CardRuntime
{
    //Runtime representation of a card
    public string Id;
    public string CardName;
    public CardType CardType;
    public bool IsUnlocked = false;
    
    
    public CardRuntime(string id,string cardName, CardType cardType, bool isUnlocked)
    {
        CardName = cardName;
        CardType = cardType;
        IsUnlocked = isUnlocked;
        Id = id;
    }
}