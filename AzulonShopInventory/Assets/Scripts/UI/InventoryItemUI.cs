using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryItemUI : MonoBehaviour
{
    public Image iconImage;
    public TextMeshProUGUI nameText;

    public void Setup(InventoryItem item)
    {
        iconImage.sprite = item.item.icon;
        nameText.text = item.item.itemName;
    }
}
