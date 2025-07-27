using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryItemPrefab;
    public Transform inventoryContainer;
    public InventoryManager inventoryManager;

    void Start()
    {
        PopulateInventory(inventoryManager.GetInventoryItems());
    }

    public void ShowInventory()
    {
        PopulateInventory(inventoryManager.GetInventoryItems());
    }

    public void PopulateInventory(List<InventoryItem> items)
    {
        foreach (Transform child in inventoryContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (InventoryItem item in items)
        {
            GameObject uiGO = Instantiate(inventoryItemPrefab, inventoryContainer);
            InventoryItemUI itemUI = uiGO.GetComponent<InventoryItemUI>();
            itemUI.Setup(item);
        }
    }
}


