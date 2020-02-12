using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class FactionTypeCreator : EditorWindow
{
    FactionTypeContainer container;

    [MenuItem("Window/AIconomy/FactionTypeCreator")]
    public static void ShowWindow()
    {
        GetWindow<FactionTypeCreator>(false, "Faction Type Creator", true);
    }

    // Start is called before the first frame update
    void Start()
    {
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
            if (obj.GetComponent<FactionTypeContainer>() == null) //obj does exist with container
            {
                obj.AddComponent<FactionTypeContainer>();
            }
            container = obj.GetComponent<FactionTypeContainer>();
        }
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
                container.addFaction(name, desired, surplus);
            }
        }
    }
}
