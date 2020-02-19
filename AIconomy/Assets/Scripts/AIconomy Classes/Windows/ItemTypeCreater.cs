using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemTypeCreater : EditorWindow
{
    string Iname = "";

    [MenuItem("Window/AIconomy/ItemTypeCreator")]
    public static void ShowWindow()
    {
        GetWindow<ItemTypeCreater>(false, "Item Type Creator", true);
    }



    ItemTypeContainer checkObjExist()
    {
        ItemTypeContainer container;
        GameObject obj;
        if (!GameObject.Find("AIC_ITEM_TYPE_CONTAINER")) //obj doesnt exist
        {
            obj = new GameObject();
            obj.name = "AIC_ITEM_TYPE_CONTAINER";
            obj.AddComponent<ItemTypeContainer>();
            container = obj.GetComponent<ItemTypeContainer>();
        }
        else
        {
            obj = GameObject.Find("AIC_ITEM_TYPE_CONTAINER");
            if (obj.GetComponent<ItemTypeContainer>() == null) //obj does exist with container
            {
                obj.AddComponent<ItemTypeContainer>();
            }
            container = obj.GetComponent<ItemTypeContainer>();
        }

        return container;
    }

    private void OnGUI()
    {
        Iname = EditorGUILayout.TextField("Name of Item Category", Iname);

        if (GUILayout.Button("Build Item"))
        {
            checkObjExist();
            
            if (Iname != null)
            {
                checkObjExist().addItem(Iname);
            }
        }
    }
}
