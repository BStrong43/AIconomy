using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public enum itemType { unassigned, utility, substance, food, weapon, ammo, tool, electronic, custom_1, custom_2, custom_3, custom_4, custom_5, custom_6 }
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
