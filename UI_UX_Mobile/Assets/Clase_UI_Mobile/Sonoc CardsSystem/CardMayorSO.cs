using UnityEngine;
[CreateAssetMenu(fileName = "New Card Mayor", menuName = "Sonoc Cards System/Card Mayor")]
public class CardMayorSO : CardData_SO
{
    [Header("Card Mayor Specific Info")]
    [SerializeField] private CardData_SO[] relatedCards;
    public CardData_SO[] RelatedCards => relatedCards;
}
