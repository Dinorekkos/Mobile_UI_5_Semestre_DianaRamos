using System;
using System.Collections.Generic;
using Dino.UtilityTools.Singleton;
using NaughtyAttributes;
using UnityEngine;

public class DinoGameManager : Singleton<DinoGameManager>
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private List<ItemData> items;
    public UIManager  UIManager => uiManager;

    public List<ItemData> Items => items;

    private void Start()
    {
        
       
        
    }


    [Button]
    private void CreateAllItems()
    {
        InventoryUI inventoryUI = UIManager.Instance.GetUIWindow(WindowsIDs.Inventory) as InventoryUI;
        if (inventoryUI == null) return;
        inventoryUI.CreateItems(items);
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
