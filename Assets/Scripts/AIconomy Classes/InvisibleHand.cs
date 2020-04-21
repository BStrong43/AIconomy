using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleHand : MonoBehaviour
{
    [Range(1, 10)]
    [Tooltip("Number of trades each inventory will do when trading")]
    public int numTrades = 1;

    InventoryScript[] inventories;
    int acceptedValueDifference = 0;
    void Start()
    {
        acceptedValueDifference = Object.FindObjectOfType<TransactionHandler>().acceptedValueDifference;
    }

    //This is a very expensive call
    //This should only be used sparingly or asynchronously
    public void doTrade()
    {
        loadInventories();

        foreach(InventoryScript i in inventories)
        {
            for(int j = 0; j < numTrades; j++)
            {
                //Index of item up for trade by inventory
                int itemForTrade = getRandomIndex(i.items.Count);
                //index of the other inventory
                int otherInv = getRandomIndex(inventories.Length);
                //Value of item up for trade based on this inventory's desired/disliked
                int tradeVal = i.items[itemForTrade].GetComponent<ItemScript>().baseValue +
                    getPriceChange(i, i.items[itemForTrade].GetComponent<ItemScript>().getItemType());

                //Index of item traded to inventory
                int itemToTake = findBeneficialTrade(tradeVal, otherInv);

                if (itemToTake <= 0)
                {
                    i.addItem(inventories[otherInv].items[itemToTake]);
                    inventories[otherInv].addItem(i.items[itemForTrade]);

                    i.removeItem(itemForTrade);
                    inventories[otherInv].removeItem(itemToTake);
                }
            }
        }
    }

    private void loadInventories()
    {
        inventories = Object.FindObjectsOfType<InventoryScript>();
    }

    private int getRandomIndex(int maxIndex)
    {
        return Random.Range(0, maxIndex);
    }


    private int findBeneficialTrade(int valueOfTrade, int o)
    {
        //Container for possible trades of item indexes with given inventory
        //X is index of item
        //Y is potential net gain from trading that item
        List<Vector2> potentialTrades = new List<Vector2>();

        //Evaluate items for trading
        for(int i=0; i<inventories[o].items.Count; i++)
        {
            //Get value of item to assess potential trade
            int netGain = inventories[o].items[i].GetComponent<ItemScript>().baseValue - valueOfTrade;

            if (Mathf.Abs(netGain) <= acceptedValueDifference)
            {
                potentialTrades.Add(new Vector2(i, netGain));
            }
        }

        if(potentialTrades.Count == 0) //No potential trades found
        {
            return -1;
        }

        //find best possible trade
        float bestValue = potentialTrades[0].y;
        int bestIndex = 0;

        for(int i = 0; i<potentialTrades.Count && potentialTrades.Count > 1; i++)
        {
            if(potentialTrades[i].y > bestValue)
            {
                bestValue = potentialTrades[i].y;
                bestIndex = i;
            }
        }

        return (int)potentialTrades[bestIndex].x;
    }

    private int getPriceChange(InventoryScript inv, int itemType)
    {
        if (itemType == (int)inv.desired)
            return 3;
        if (itemType == (int)inv.disliked)
            return -3;

        return 0;
            
    }
}
