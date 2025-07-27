using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ShopUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject shopItemPrefab;
    public Transform shopItemContainer;
    public ShopManager shopManager;

    void Start()
    {
        PopulateShop(shopManager.GetShopItems());
    }

    public void OnBuyButtonClicked(ShopItem item)
    {
        Debug.Log("Buy: " + item.itemName);
        shopManager.TryPurchaseItem(item);
    }

    public void PopulateShop(List<ShopItem> items)
    {
        foreach (Transform child in shopItemContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (ShopItem item in items)
        {
            GameObject uiGO = Instantiate(shopItemPrefab, shopItemContainer);
            ShopItemUI itemUI = uiGO.GetComponent<ShopItemUI>(); 
            itemUI.Setup(item, () => OnBuyButtonClicked(item));
        }
    }
}
