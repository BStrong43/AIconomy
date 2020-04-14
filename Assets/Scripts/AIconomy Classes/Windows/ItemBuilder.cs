using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public struct ItemType
{
    public string iName;
}

public class ItemBuilder : EditorWindow
{
    GameObject item;
    string itemName, desc;
    Sprite j;
    int value;
    ItemScript.itemType itemType;
    [MenuItem("Window/AIconomy/ItemBuilder")]
    
    public static void ShowWindow()
    {
        GetWindow<ItemBuilder>(false, "Item Builder", true);
    }

    void OnGUI()
    {
        itemName = EditorGUILayout.TextField("Name of Item", itemName);
        j = EditorGUILayout.ObjectField("Item Sprite", j, typeof(Sprite), true) as Sprite;
        value = (int)EditorGUILayout.IntField(value);
        itemType = (ItemScript.itemType)EditorGUILayout.EnumPopup("Type of Item", itemType);
        desc = EditorGUILayout.TextArea(desc);
        if (GUILayout.Button("Build Item"))
        {
            if (itemName != null && j != null)
            {
                item = new GameObject();
                item.AddComponent<ItemScript>();
                item.GetComponent<ItemScript>().baseValue = value;
                item.GetComponent<ItemScript>().icon = j;
                item.GetComponent<ItemScript>().itemDesc = desc;
                item.name = itemName;
            }
            else Debug.Log("Item could not be built. Input field null");
            
        }
    }
}
