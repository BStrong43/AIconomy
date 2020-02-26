using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public enum itemType { unassigned, utility, substance, food }
    public int baseValue;
    public Sprite icon;
    public itemType type;
    public string itemDesc;
    
    public int getValue()
    {
        return baseValue;
    }

    public Sprite getIcon()
    {
        return icon;
    }

    public int getItemType()
    {
        return (int)type;
    }

    public string getDesc()
    {
        return itemDesc;
    }
}
