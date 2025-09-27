using System;
using System.Collections;
using Dino.UtilityTools.Extensions;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    [SerializeField] Scrollbar  scrollbar;
    [SerializeField] Button  buttnoMap;
    [SerializeField] Button  buttonInventory;
    [SerializeField] Button  buttonSettings;

    private Coroutine smoothScrollCoroutine;
    
    private float MapUI = 0f;
    private float InventoryUI = 0.5f;
    private float SettingsUI = 1f;
    

    private void Start()
    {
        
        buttnoMap.onClick.AddListener(() => MoveToUI(MapUI));
        buttonInventory.onClick.AddListener(() => MoveToUI(InventoryUI));
        buttonSettings.onClick.AddListener(() => MoveToUI(SettingsUI));
    }
    
    
    private void MoveToUI(float value)
    {
        if (smoothScrollCoroutine != null)
            StopCoroutine(smoothScrollCoroutine);
        
        smoothScrollCoroutine = StartCoroutine(SmoothSetScrollbarValue(value, 0.3f)); // 0.3 segundos de duración
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
