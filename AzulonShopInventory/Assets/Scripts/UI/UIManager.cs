using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject inventoryPanel;

    public void ShowShop()
    {
        shopPanel.SetActive(true);
        inventoryPanel.SetActive(false);
    }

    public void ShowInventory()
    {
        shopPanel.SetActive(false);
        inventoryPanel.SetActive(true);

        InventoryUI inventoryUI = inventoryPanel.GetComponent<InventoryUI>();
        inventoryUI.ShowInventory();
    }
}


