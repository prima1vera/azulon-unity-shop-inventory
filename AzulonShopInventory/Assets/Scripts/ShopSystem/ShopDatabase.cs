using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopDatabase", menuName = "Shop/Shop Database")]
public class ShopDatabase : ScriptableObject
{
    public List<ShopItem> items;
}
