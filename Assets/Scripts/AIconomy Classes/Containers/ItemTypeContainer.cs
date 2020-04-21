using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTypeContainer : MonoBehaviour
{
    [SerializeField]
    ItemType[] itemTypes = null;

    public int foo;

    public void addItem(string name)
    {
        if(itemTypes == null)
        {
            Debug.Log("itemTypes is null");
            //itemTypes = new List<ItemType>();
        }

        Debug.Log("Item Added: " + name);
        ItemType item;
        foo++;
        item.iName = name;
        //itemTypes.Add(item);
    }

    private void Start()
    {
        Debug.Log(itemTypes);
    }
}