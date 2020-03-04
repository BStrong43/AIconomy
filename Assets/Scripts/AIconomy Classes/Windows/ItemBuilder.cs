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
    string itemName;
    Sprite j;
    ItemType itemType;
    [MenuItem("Window/AIconomy/ItemBuilder")]
    
    public static void ShowWindow()
    {
        GetWindow<ItemBuilder>(false, "Item Builder", true);
    }

    void OnGUI()
    {
        itemName = EditorGUILayout.TextField("Name of Item", itemName);
        j = EditorGUILayout.ObjectField("Item Sprite", j, typeof(Sprite), true) as Sprite;
        //itemType = EditorGUI.DropDownMenu(listOfItemTypes);
        if (GUILayout.Button("Build Item"))
        {
            if (name != null && j != null /*&& itemType != null*/)
            {
                item = new GameObject();

            }
            else Debug.Log("Item could not be built. Input field null");
            
        }
    }
}
