using System;

[Serializable]
public class CardRuntime
{
    //Runtime representation of a card
    public string CardName;
    public string Description;
    public CardType CardType;
    
    public CardRuntime(string cardName, string description, CardType cardType)
    {
        CardName = cardName;
        Description = description;
        CardType = cardType;
    }
}