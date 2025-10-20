using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "CardData")]
public class CardData : ScriptableObject
{
    private Sprite _sprite;
    private string cardName;
    private string _description;
    private CardType _cardType;
    
    public Sprite Sprite => _sprite;
    public string CardName => cardName;
    public string Description => _description;
    public CardType CardType => _cardType;
    
}

public enum CardType
{
    Attack,
    Defense,
    Magic
}