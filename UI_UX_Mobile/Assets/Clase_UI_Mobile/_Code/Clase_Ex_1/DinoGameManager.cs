using System;
using Dino.UtilityTools.Singleton;
using NaughtyAttributes;
using UnityEngine;

public class DinoGameManager : Singleton<DinoGameManager>
{
    [SerializeField] private UIManager uiManager;
    public UIManager  UIManager => uiManager;


    private void Start()
    {
        
       
        
    }

    [Button]
    private void ShowPopUp()
    {
        PopupUI popupUI = UIManager.Instance.GetUIWindow(WindowsIDs.Popup) as PopupUI;
        popupUI.Show();
    }

    [Button]
    private void ChangePopupText()
    {
        PopupUI popupUI = UIManager.Instance.GetUIWindow(WindowsIDs.Popup) as PopupUI;
        popupUI.SetPopup("Soy Dino");
    }

    [Button]
    private void HidePopup()
    {
        UIManager.Instance.HideUI(WindowsIDs.Popup);
    }
}
