using System;

[Serializable]
public class CardRuntime
{
    //Runtime representation of a card
    public string ID;
    public string CardName;
    public string Description;
    public CardType CardType;
    
    public CardRuntime(string id, string cardName, string description, CardType cardType)
    {
        ID = id;
        CardName = cardName;
        Description = description;
        CardType = cardType;
    }
}