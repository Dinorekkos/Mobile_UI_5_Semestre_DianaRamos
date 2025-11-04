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
            if(_cardButton != null) 
                _cardButton.onClick.AddListener(OnCardClicked);
        }


        public void SetupCardUI(CardRuntime cardRuntime)
        {
            _cardRuntime = cardRuntime;
            _cardImage.sprite = cardRuntime.CardData_SO.Sprite;
        }
        
        public void SetUnlocked(bool isUnlocked)
        {
            // Example logic to visually indicate locked/unlocked state
            _cardImage.color = isUnlocked ? Color.white : Color.gray;
        }

        // public void DisableButton()
        // {
        //     if(_cardButton != null)
        //         _cardButton.enabled = false;
        // }
        private void OnCardClicked()
        {
            Debug.Log($"Card {_cardRuntime.CardName} clicked!");
            if (_cardRuntime == null)
            {
                Debug.LogWarning("CardRuntime is null. Cannot unlock card.");
                return;
            }
            CardsManagerSonoc.Instance.SetCardAsUnlocked(_cardRuntime.Id);
            
        }
    }
}
