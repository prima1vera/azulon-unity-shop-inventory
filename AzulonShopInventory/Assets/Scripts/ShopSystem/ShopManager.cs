using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public InventoryManager inventory;
    public float playerMoney = 100;
    public ShopDatabase shopDatabase;

    public TextMeshProUGUI moneyText;

    private void Start()
    {
        UpdateMoneyUI();
    }

    public void TryPurchaseItem(ShopItem item)
    {
        if (playerMoney >= item.price)
        {
            playerMoney -= item.price;

            inventory.AddItem(item);
            UpdateMoneyUI();

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
    private void UpdateMoneyUI()
    {
        if (moneyText != null)
        {
            moneyText.text = $"Money: ${playerMoney}";
        }
    }

    void Awake()
    {
        LoadPlayerMoney();
        inventory.LoadInventory(shopDatabase.items);
    }

    void OnApplicationQuit()
    {
        SavePlayerMoney();
        inventory.SaveInventory();
    }

    public void SavePlayerMoney()
    {
        PlayerPrefs.SetFloat("PlayerMoney", (float)playerMoney);
        PlayerPrefs.Save();
    }

    public void LoadPlayerMoney()
    {
        playerMoney = PlayerPrefs.GetFloat("PlayerMoney", 100f);
    }

    public void ResetShop()
    {
        playerMoney = 100;
        inventory.items.Clear();
        UpdateMoneyUI();

        Debug.Log("Game Reset: Inventory cleared and money restored.");
    }
}
