using System;
using System.Collections;
using System.Collections.Generic;
using Dino.UtilityTools.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] Scrollbar  scrollbar;
    [SerializeField] Button  buttonMap;
    [SerializeField] Button  buttonShop;
    [SerializeField] Button  buttonGacha;
    [SerializeField] Button   buttonCharacter;

    private Coroutine smoothScrollCoroutine;
    
    private float MapUI = 0.333333333f;
    private float InventoryUI = 0f;
    private float GachaUI = 0.6666666f;
    private float CharacterUI = 1f;

    [SerializeField] private List<Sprite> sprites;
    [SerializeField]private Sprite previousSprite;
    [SerializeField] private Button previousButton;
    
    [Header("Header Bar")]
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private TextMeshProUGUI _goldAmount;
    [SerializeField] private TextMeshProUGUI _diamondsAmount;
    [SerializeField] private TextMeshProUGUI _levelAmount;
    [SerializeField] private Image _levelImage;
    

    private void Start()
    {
        
        buttonMap.onClick.AddListener(() => MoveToUI(MapUI, 0, buttonMap));
        buttonShop.onClick.AddListener(() => MoveToUI(InventoryUI, 1, buttonShop));
        buttonGacha.onClick.AddListener(() => MoveToUI(GachaUI, 2, buttonGacha));
        buttonCharacter.onClick.AddListener(() => MoveToUI(CharacterUI, 3, buttonCharacter));
        MoveToUI(MapUI, 0, buttonMap);
        
    }
    
    
    private void MoveToUI(float value, int sprite, Button button)
    {
        if (smoothScrollCoroutine != null)
            StopCoroutine(smoothScrollCoroutine);
        
        smoothScrollCoroutine = StartCoroutine(SmoothSetScrollbarValue(value, 0.3f)); // 0.3 segundos de duración
        previousButton.gameObject.GetComponent<Image>().sprite = previousSprite;
        previousButton = button;
        previousSprite =  button.gameObject.GetComponent<Image>().sprite;
        button.gameObject.GetComponent<Image>().sprite = sprites[sprite];;
    }
    private IEnumerator SmoothSetScrollbarValue(float targetValue, float duration)
    {
        float startValue = scrollbar.value;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            scrollbar.value = Mathf.Lerp(startValue, targetValue, elapsed / duration);
            yield return null;
        }
        scrollbar.value = targetValue;
      
    }
    
}
