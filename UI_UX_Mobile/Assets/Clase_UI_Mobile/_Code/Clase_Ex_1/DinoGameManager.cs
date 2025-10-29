using System;
using System.Collections.Generic;
using Dino.UtilityTools.Singleton;
using NaughtyAttributes;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class DinoGameManager : Singleton<DinoGameManager>
{
    public UIManager  UIManager => UIManager.Instance;
    public CardsManager CardsManager => CardsManager.Instance;
    
    private void Start()
    {
    }


   
    
    

    #region Examples of Popup Usage
    private void ShowPopUp()
    {
        PopupUI popupUI = UIManager.Instance.GetUIWindow(WindowsIDs.Popup) as PopupUI;
        popupUI.Show();
    }

    private void ChangePopupText()
    {
        PopupUI popupUI = UIManager.Instance.GetUIWindow(WindowsIDs.Popup) as PopupUI;
        popupUI.SetPopup("Soy Dino");
    }
    
    private void HidePopup()
    {
        UIManager.Instance.HideUI(WindowsIDs.Popup);
    }
    
    #endregion
    
}
