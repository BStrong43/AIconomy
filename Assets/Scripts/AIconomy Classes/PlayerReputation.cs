using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReputation : MonoBehaviour
{
    public enum Gangs { unassigned, red, blue, green, yellow, orange, purple }
    public Gangs currentClan;
    public float startingCredValue;
    public float maxCred;
    public float minCred;
    public float blueCred, greenCred, redCred;
    int streetCred = 0; //Universal reputation value

    Dictionary<Gangs, float> reputationIndex;
    
    void Start()
    {
        reputationIndex = new Dictionary<Gangs, float>();
        loadGangs();
    }

    void loadGangs()
    { 
        reputationIndex.Add(Gangs.blue  , startingCredValue);
        reputationIndex.Add(Gangs.red   , startingCredValue);
        reputationIndex.Add(Gangs.green , startingCredValue);
        reputationIndex.Add(Gangs.yellow, startingCredValue);
        reputationIndex.Add(Gangs.orange, startingCredValue);
        reputationIndex.Add(Gangs.purple, startingCredValue);
    }

    public void changeRep(Gangs gang, float repChange)
    {
        reputationIndex[gang] += repChange;
    }

    public float getRep(Gangs gang)
    {
        return reputationIndex[gang];
    }

    public int getCurrentClan()
    {
        return (int)currentClan;
    }
    public int getCred()
    {
        return streetCred;
    }
}
