using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject inventoryPanel;
    public TextMeshProUGUI feedbackText;
    public ShopManager shopManager;

    public void ShowShop()
    {
        StateManager.SetState(GameState.Shop);
        shopPanel.SetActive(true);
        inventoryPanel.SetActive(false);
    }

    public void ShowInventory()
    {
        StateManager.SetState(GameState.Inventory);
        shopPanel.SetActive(false);
        inventoryPanel.SetActive(true);

        InventoryUI inventoryUI = inventoryPanel.GetComponent<InventoryUI>();
        inventoryUI.ShowInventory();
    }

    public void ShowMessage(string msg)
    {
        feedbackText.text = msg;
        feedbackText.gameObject.SetActive(true);
        CancelInvoke(nameof(HideMessage));
        Invoke(nameof(HideMessage), 2f);
    }

    void HideMessage()
    {
        feedbackText.gameObject.SetActive(false);
    }

    public void ResetGame()
    {
        shopManager.ResetShop();

        shopPanel.GetComponent<ShopUI>().PopulateShop(shopManager.GetShopItems());
        inventoryPanel.GetComponent<InventoryUI>().ShowInventory();
    }
}


