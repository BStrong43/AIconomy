using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReputation : MonoBehaviour
{
    public enum Gangs { unassigned, red, blue, green }
    public Gangs currentClan;
    public float maxCred;
    public float minCred;
    public float blueCred, greenCred, redCred;
    int streetCred = 0;

    Dictionary<Gangs, float> reputationIndex = new Dictionary<Gangs, float>();
    
    void Start()
    {
        //loadGangs();
        
    }

    void loadGangs()
    { 
        reputationIndex.Add(Gangs.blue , 1.0f);
        reputationIndex.Add(Gangs.red  , 1.0f);
        reputationIndex.Add(Gangs.green, 1.0f);
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
