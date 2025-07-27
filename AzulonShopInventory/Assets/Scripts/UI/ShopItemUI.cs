using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class ShopItemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    public Button buyButton;

    public void Setup(ShopItem item, UnityAction onBuy)
    {
        iconImage.sprite = item.icon;
        nameText.text = item.itemName;
        priceText.text = $"${item.price}";

        buyButton.onClick.AddListener(onBuy);
    }
}
