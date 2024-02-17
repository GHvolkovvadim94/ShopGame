using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Item
{
    public string ItemName { get; private set; }
    public int Price { get; private set; }
    public Item(string itemName, int price)
    {
        ItemName = itemName;
        Price = price;
    }
}
