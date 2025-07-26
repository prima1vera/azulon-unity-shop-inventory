using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem
{
    public string id;
    public string itemName;
    public Sprite icon;
    public string description;
    public int price;

    public ShopItem(string id, string name, Sprite icon, string description, int price)
    {
        this.id = id;
        this.itemName = name;
        this.icon = icon;
        this.description = description;
        this.price = price;
    }
}
