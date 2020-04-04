using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FactionTypeCreator : EditorWindow
{
    

    [MenuItem("Window/AIconomy/FactionTypeCreator[DEPRACATED]")]
    public static void ShowWindow()
    {
        GetWindow<FactionTypeCreator>(false, "Faction Type Creator", true);
    }

    // Start is called before the first frame update
    FactionTypeContainer checkObjExists()
    {
        FactionTypeContainer container;
        GameObject obj;
        if (!GameObject.Find("AIC_FACTION_TYPE_CONTAINER")) //obj doesnt exist
        {
            obj = new GameObject();
            obj.name = "AIC_FACTION_TYPE_CONTAINER";
            obj.AddComponent<FactionTypeContainer>();
            container = obj.GetComponent<FactionTypeContainer>();
        }
        else
        {
            obj = GameObject.Find("AIC_FACTION_TYPE_CONTAINER");
            if (obj.GetComponent<FactionTypeContainer>() == null) 
            {
                obj.AddComponent<FactionTypeContainer>(); //obj does exist without container
            }
            container = obj.GetComponent<FactionTypeContainer>();
        }
        return container;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        string name = EditorGUILayout.TextField("Name of Item Category");

        if (GUILayout.Button("Build Item"))
        {
            ItemType desired, surplus;
            desired.iName = "Weapons";
            surplus.iName = "Food";

            if (name != null)
            {
                checkObjExists().addFaction(name, desired, surplus);
            }
        }
    }
}
