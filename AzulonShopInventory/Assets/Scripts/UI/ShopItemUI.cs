using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;
using Unity.VisualScripting;

public class ShopItemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI priceText;
    public Button buyButton;
    public TextMeshProUGUI description;

    public void Setup(ShopItem item, UnityAction onBuy)
    {
        iconImage.sprite = item.icon;
        nameText.text = item.itemName;
        priceText.text = $"${item.price}";
        description.text = item.description;

        buyButton.onClick.AddListener(onBuy);
    }
}
