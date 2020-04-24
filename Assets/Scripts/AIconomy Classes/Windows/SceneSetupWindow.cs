using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SceneSetupWindow : EditorWindow
{
    [MenuItem("Window/AIconomy/Scene Setup")]
    public static void ShowWindow()
    {
        GetWindow<SceneSetupWindow>(false, "Item Type Creator", true);
    }

    bool setupHand = false;
    void buildHand()
    {
        GameObject obj;
        if (!GameObject.Find("AIC_Invisible_Hand"))
        {//obj doesnt exist
            obj = new GameObject();
            obj.name = "AIC_Invisible_Hand";
            obj.AddComponent<InvisibleHand>();
            
        }
        else
        {//obj exists
            obj = GameObject.Find("AIC_Invisible_Hand");
            if (obj.GetComponent<InvisibleHand>() == null) //obj does exist with container
            {
                obj.AddComponent<InvisibleHand>();
            }
        }
    }

    void buildTraHandler()
    {
        GameObject obj;
        if (!GameObject.Find("AIC_Transaction_Handler")) //obj doesnt exist
        {
            obj = new GameObject();
            obj.name = "AIC_Transaction_Handler";
            obj.AddComponent<TransactionHandler>();
        }
        else
        {
            obj = GameObject.Find("AIC_Transaction_Handler");
            if (obj.GetComponent<TransactionHandler>() == null) //obj does exist with container
            {
                obj.AddComponent<TransactionHandler>();
            }
        }
    }

    private void OnGUI()
    {
        setupHand = EditorGUILayout.Toggle("Set up Inisible Hand?", setupHand);

        if (GUILayout.Button("Set up Scene"))
        {
            buildTraHandler();
            if (setupHand)
            {
                buildHand();
            }
        }
    }
}
