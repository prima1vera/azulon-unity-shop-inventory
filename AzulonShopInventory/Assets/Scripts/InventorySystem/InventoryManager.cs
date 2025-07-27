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

    [System.Serializable]
    class InventorySaveData
    {
        public List<string> itemIDs = new List<string>();
    }

    public void SaveInventory()
    {
        InventorySaveData saveData = new InventorySaveData();

        foreach (var item in items)
        {
            saveData.itemIDs.Add(item.item.id);
        }

        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString("InventoryData", json);
        PlayerPrefs.Save();
    }

    public void LoadInventory(List<ShopItem> allShopItems)
    {
        items.Clear();

        string json = PlayerPrefs.GetString("InventoryData", "");
        if (string.IsNullOrEmpty(json)) return;

        InventorySaveData saveData = JsonUtility.FromJson<InventorySaveData>(json);

        foreach (string id in saveData.itemIDs)
        {
            ShopItem matchedItem = allShopItems.Find(item => item.id == id);
            if (matchedItem != null)
            {
                items.Add(new InventoryItem(matchedItem));
            }
            else
            {
                Debug.LogWarning($"Item with ID {id} not found in ShopDatabase.");
            }
        }
    }
}
