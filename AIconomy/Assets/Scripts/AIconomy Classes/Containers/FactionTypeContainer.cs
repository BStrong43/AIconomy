using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FactionType
{
    public string fName;
    public ItemType desiredType;
    public ItemType surplusType;

    public FactionType(string name, ItemType desired, ItemType surplus)
    {
        fName = name;
        desiredType = desired;
        surplusType = surplus;
    }
}

public class FactionTypeContainer : MonoBehaviour
{
    public List<FactionType> factions = new List<FactionType>();

    public void addFaction(string name, ItemType desired, ItemType surplus)
    {
        FactionType fac = new FactionType(name, desired, surplus);
        factions.Add(fac);
    }
}
