using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemBuilder : EditorWindow
{
    string name;
    Sprite j;    //ItemType itemType;
    [MenuItem("Window/ItemBuilder")]
    
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(ItemBuilder));
    }

    void Update()
    {

    }

    private void onGUI()
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
