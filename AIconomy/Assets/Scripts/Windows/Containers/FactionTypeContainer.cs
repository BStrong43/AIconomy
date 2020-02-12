using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FactionType
{
    public string fName;
    public ItemType desiredType;
    public ItemType surplusType;
}

public class FactionTypeContainer : MonoBehaviour
{
    public List<FactionType> factions = new List<FactionType>();

    public void addFaction(string name, ItemType desired, ItemType surplus)
    {
        FactionType fac;
        fac.fName = name;
        fac.desiredType = desired;
        fac.surplusType = surplus;

        factions.Add(fac);
    }
}
