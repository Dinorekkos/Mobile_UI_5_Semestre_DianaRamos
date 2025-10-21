using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    [Header("Card UI")]
    [SerializeField] private Image cardImage;
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI descriptionText;

    public void SetupCardUI(CardRuntime cardRuntime)
    {
        cardNameText.text = cardRuntime.CardName;
        descriptionText.text = cardRuntime.Description;
        // Here you would set the image based on the CardType or other properties
        // For example, you might have a method to get the sprite based on CardType
        // cardImage.sprite = GetSpriteForCardType(cardRuntime.CardType);
    }
}
