using System;
using Dino.UtilityTools.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PopupUI : UIWindow
{
    #region Popup implementation
    
    #region serialized Fields

    [Header("Popup Settings")] 
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _buttonYes;
    [SerializeField] private Button _buttonNo;
    #endregion
    
    public override void Initialize()
    {
        base.Initialize();
        _buttonNo.onClick.AddListener(NoClick);
        _buttonYes.onClick.AddListener(YesClick);
        
        _text.text = string.Empty;
    }

    private void OnDestroy()
    {
        _buttonNo.onClick.RemoveListener(NoClick);
        _buttonYes.onClick.RemoveListener(YesClick);
    }

    public void SetPopup(string text)
    {
        _text.text = text;
    }
    
    private void YesClick()
    {
        Debug.Log("Yes Clicked");
    }
    private void NoClick()
    {
        Debug.Log("No clicked");
    }
    #endregion
}
