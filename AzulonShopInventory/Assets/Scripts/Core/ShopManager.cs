using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Inventory inventory;
    public int playerMoney = 100;
    public ShopDatabase shopDatabase;

    public void TryPurchaseItem(ShopItem item)
    {
        if (playerMoney >= item.price)
        {
            playerMoney -= item.price;

            inventory.AddItem(item);

            Debug.Log($"Purchased {item.itemName} for ${item.price}. Remaining money: ${playerMoney}");
        }
        else
        {
            Debug.LogWarning($"Not enough money to purchase {item.itemName}");
        }
    }

    public List<ShopItem> GetShopItems()
    {
        return shopDatabase.items;
    }
}
