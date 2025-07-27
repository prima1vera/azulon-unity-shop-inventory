using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ShopItemUI : MonoBehaviour
{
    [Header("UI References")]
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    public Button buyButton;

    private ShopItem itemData;
    private ShopManager shopManager;

    public void Initialize(ShopItem item, ShopManager manager)
    {
        itemData = item;
        shopManager = manager;

        iconImage.sprite = item.icon;
        nameText.text = item.itemName;
        priceText.text = $"${item.price}";

        buyButton.onClick.AddListener(OnBuyClicked);
    }

    private void OnBuyClicked()
    {
        shopManager.TryPurchaseItem(itemData);
    }

    public void Setup(ShopItem item, UnityAction onBuy)
    {
        iconImage.sprite = item.icon;
        nameText.text = item.itemName;
        priceText.text = $"${item.price}";
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(onBuy);
    }
}
