﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public struct ItemType
{
    public string iName;
}

public class ItemBuilder : EditorWindow
{
    string name;
    Sprite j;
    ItemType itemType;
    [MenuItem("Window/AIconomy/ItemBuilder")]
    
    public static void ShowWindow()
    {
        GetWindow<ItemBuilder>(false, "Item Builder", true);
    }

    void Update()
    {

    }

    void OnGUI()
    {
        name = EditorGUILayout.TextField("Name of Item", name);
        j = EditorGUILayout.ObjectField("Item Sprite", j, typeof(Sprite), true) as Sprite;
        //itemType = EditorGUI.DropDownMenu(listOfItemTypes);
        if (GUILayout.Button("Build Item"))
        {
            if(name != null && j != null /*&& itemType != null*/)
            {
                //build item
            }
            
        }
    }
}
