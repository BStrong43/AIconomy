using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTypeContainer : MonoBehaviour
{
    public List<ItemType> itemTypes = new List<ItemType>();

    public void addItem(string name)
    {
        ItemType item;
        item.iName = name;

        itemTypes.Add(item);
    }
}