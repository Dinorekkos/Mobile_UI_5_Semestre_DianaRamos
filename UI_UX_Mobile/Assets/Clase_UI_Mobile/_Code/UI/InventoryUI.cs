using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class InventoryUI : UIWindow
{
    [Header("Inventory UI")]
    [BoxGroup("Inventory")] [SerializeField] private GameObject itemPrefab;
    [BoxGroup("Inventory")] [SerializeField] private GameObject content;



    
    
    public void CreateItems(List<CardDataSO> items)
    {
        foreach (var item in items)
        {
            SpawnItem(item);
        }
        
    }
    
    private void SpawnItem(CardDataSO cardDataSo)
    {
        GameObject go = Instantiate(itemPrefab, content.transform);
        InventoryItem item = go.GetComponent<InventoryItem>();
        item.SetInfo(cardDataSo.Sprite, cardDataSo.CardName);
    }
    
    
}
