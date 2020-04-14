using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class InventoryBuilder : EditorWindow
{
    // Start is called before the first frame update
    GameObject obj;
    ItemScript.itemType desiredType;
    ItemScript.itemType dislikedType;
    [MenuItem("Window/AIconomy/InventoryBuilder")]

    public static void ShowWindow()
    {
        GetWindow<InventoryBuilder>(false, "Inventory Builder", true);
    }

    // Update is called once per frame
    void OnGUI()
    {
        obj = EditorGUILayout.ObjectField("Recieving Object", obj, typeof(GameObject), true) as GameObject;
        desiredType = (ItemScript.itemType)EditorGUILayout.EnumPopup("Desired Item Type", desiredType);
        dislikedType = (ItemScript.itemType)EditorGUILayout.EnumPopup("Disliked Item Type", dislikedType);

        if (GUILayout.Button("Assign Inventory"))
        {
            if (obj != null)
            {
                obj.AddComponent<InventoryScript>();
                obj.GetComponent<InventoryScript>().desired = desiredType;
                obj.GetComponent<InventoryScript>().disliked = dislikedType;
            }
            else Debug.Log("Inventory was not assigned. Input field null");

        }
    }
}
