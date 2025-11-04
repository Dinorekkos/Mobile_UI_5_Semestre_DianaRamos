using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;

namespace SonocCardsSystem
{
    public class CardUI : MonoBehaviour
    {
        [SerializeField] private Image _cardImage;
        [SerializeField] private Button _cardButton;

        [ReadOnly, SerializeField] private CardRuntime _cardRuntime;

        private void Start()
        {
            _cardButton = gameObject.GetComponent<Button>();
            _cardImage = gameObject.GetComponent<Image>();

            _cardButton.onClick.AddListener(OnCardClicked);
        }


        public void SetupCardUI(CardRuntime cardRuntime)
        {
            _cardRuntime = cardRuntime;
            _cardImage.sprite = cardRuntime.CardData_SO.Sprite;
        }

        private void OnCardClicked()
        {
            Debug.Log($"Card {_cardRuntime.CardName} clicked!");
        }
    }
}
