using System;
using DG.Tweening;
using Dino.UtilityTools.Extensions;
using Lean.Gui;
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

    [SerializeField] private LeanHover _yesHover;
    [SerializeField] private LeanHover _noHover;
    [SerializeField] private float strengthShake = 10f;
    
    [SerializeField] private LayoutGroup layoutGroup;
    
    
#endregion
    
    public override void Initialize()
    {
        base.Initialize();
        _buttonNo.onClick.AddListener(NoClick);
        _buttonYes.onClick.AddListener(YesClick);
        
        _yesHover.OnEnter.AddListener(OnHoverYesButton);
        _noHover.OnEnter.AddListener(OnHoverNoButton);
        
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
        
        RectTransform rectTransform = _buttonYes.GetComponent<RectTransform>();
        rectTransform.DOAnchorPosY(rectTransform.anchoredPosition.y + 50f, 0.5f)
            .OnComplete(() =>
            {
                rectTransform.DOAnchorPosX(rectTransform.anchoredPosition.x + 50f, 0.5f);
            });
        
        // Hide();
    }
    private void NoClick()
    {
        Debug.Log("No clicked");
        Hide();
    }

    private void OnHoverYesButton()
    {
        Debug.Log("OnHoverYesButton".SetColor(ColorDebug.Green));
      
        
    }
    private void OnHoverNoButton()
    {
        Debug.Log("OnHoverNoButton".SetColor(ColorDebug.Red));
        
        RectTransform rectTransform = _buttonNo.GetComponent<RectTransform>();
        rectTransform.DOShakeAnchorPos(1f,strengthShake,20,90, false).OnComplete(
            () =>  LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>()));
    }
    #endregion
}
