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
    private void ShowPopTest()
    {
        PopupUI popupUI = UIManager.Instance.GetUIWindow(WindowsIDs.Popup) as PopupUI;
        if (popupUI == null)
        {
            Debug.LogError("UI Window not found");
            return;
        }
        popupUI.SetPopup("Hola");
        popupUI.Show();
    }

    [Button]
    private void ChangePopupTextTest()
    {
        PopupUI popupUI = UIManager.Instance.GetUIWindow(WindowsIDs.Popup) as PopupUI;
        if (popupUI == null)
        {
            Debug.LogError("UI Window not found");
            return;
        }
        popupUI.SetPopup("Soy Dino");
        popupUI.Show();
    }

    [Button]
    private void HidePopup()
    {
        UIManager.Instance.HideUI(WindowsIDs.Popup);
        
    }
}
