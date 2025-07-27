using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(ShopItem shopItem)
    {
        items.Add(new InventoryItem(shopItem));
    }

    public List<InventoryItem> GetInventoryItems()
    {
        return items;
    }
}
