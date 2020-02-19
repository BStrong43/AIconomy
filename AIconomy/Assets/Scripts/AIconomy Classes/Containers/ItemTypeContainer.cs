using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTypeContainer : MonoBehaviour
{
    [SerializeField]
    public List<ItemType> itemTypes = null;

    public void addItem(string name)
    {
        if(itemTypes == null)
        {
            Debug.Log("itemTypes is null");
            itemTypes = new List<ItemType>();
        }

        Debug.Log("Item Added: " + name);
        Debug.Log(itemTypes[0].iName);
        ItemType item;
        item.iName = name;
        itemTypes.Add(item);
    }
}