using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "CardData")]
public class CardDataSO : ScriptableObject
{
    //Scriptable objects only for data storage
    [SerializeField] private string _id;
    [SerializeField] private Sprite sprite;
    [SerializeField] private string cardName;
    [SerializeField] private string description;
    [SerializeField] private CardType cardType;

    public Sprite Sprite => sprite;
    public string CardName => cardName;
    public string Description => description;
    public CardType CardType => cardType;
    
    public string ID => _id;
}


public enum CardType
{
    Attack,
    Defense,
    Magic
}