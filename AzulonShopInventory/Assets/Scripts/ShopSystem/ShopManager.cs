using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public InventoryManager inventory;
    public decimal playerMoney = 100;
    public ShopDatabase shopDatabase;

    public void TryPurchaseItem(ShopItem item)
    {
        if (playerMoney >= item.price)
        {
            playerMoney -= item.price;

            inventory.AddItem(item);

            FindObjectOfType<UIManager>().ShowMessage($"Purchased {item.itemName} for ${item.price}!");
            Debug.Log($"Purchased {item.itemName} for ${item.price}. Remaining money: ${playerMoney}");
        }
        else
        {
            FindObjectOfType<UIManager>().ShowMessage("Not enough money!");
            Debug.LogWarning($"Not enough money to purchase {item.itemName}");
        }
    }

    public List<ShopItem> GetShopItems()
    {
        return shopDatabase.items;
    }
}
