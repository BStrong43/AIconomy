using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCGang : MonoBehaviour
{
    public PlayerReputation.Gangs gang;
    public ItemScript.itemType desiredType;
    public ItemScript.itemType dislikedType;

    public int getGang()
    {
        return (int)gang;
    }
    
    public int getDesiredType()
    {
        return (int)desiredType;
    }

    public int getUndesiredType()
    {
        return (int)dislikedType;
    }
}
