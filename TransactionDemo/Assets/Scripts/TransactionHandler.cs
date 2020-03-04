using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransactionHandler : MonoBehaviour
{
    public bool inDebug;

    public GameObject player, cp;
    public GameObject tradeButton, exitButton;
    public GameObject itemUI;

    public Vector3 vertItemSpacing;
    public Vector3 horizItemSpacing;

    public List<GameObject> playerInv;
    public List<GameObject> otherInv;
    public List<GameObject> playerUI;
    public List<GameObject> otherUI;

    public int acceptedValueDifference;

    void Start()
    {
        playerUI = new List<GameObject>();
        otherUI = new List<GameObject>();
        tradeButton.SetActive(false);
        exitButton.SetActive(false);

        if (inDebug)
        {
            loadInventories();
            displayInventory();
        }
    }

    public void startTrade(GameObject npc)
    {
        cp = npc;
        loadInventories();
        displayInventory();
    }

    void loadInventories()
    {
        playerInv = new List<GameObject>(player.GetComponent<InventoryScript>().getInv());
        otherInv = new List<GameObject>(cp.GetComponent<InventoryScript>().getInv());
    }

    void displayInventory()
    {
        tradeButton.SetActive(true);
        exitButton.SetActive(true);

        playerUI.Clear();
        otherUI.Clear();

        for (int i = 0; i<playerInv.Count; i++)
        {
            GameObject uiItem = Instantiate(itemUI, transform);
            playerUI.Add(uiItem);

            uiItem.GetComponent<ItemUIScript>().invIndex = i;
            uiItem.GetComponent<RectTransform>().Translate(vertItemSpacing * i);

            int price = editPrice(playerInv[i].GetComponent<ItemScript>().getValue(),
                playerInv[i].GetComponent<ItemScript>().getItemType(),
                cp.GetComponent<NPCGang>().getDesiredType(),
                cp.GetComponent<NPCGang>().getUndesiredType());

            uiItem.GetComponent<ItemUIScript>().initUI(playerInv[i].name, price,
                playerInv[i].GetComponent<ItemScript>().getIcon());
        }

        for(int i = 0; i < otherInv.Count; i++)
        {
            GameObject uiItem = Instantiate(itemUI, transform);
            otherUI.Add(uiItem);

            uiItem.GetComponent<ItemUIScript>().invIndex = i;
            uiItem.GetComponent<RectTransform>().Translate(horizItemSpacing);

            uiItem.GetComponent<RectTransform>().Translate(vertItemSpacing * i);

            int price = editPrice(otherInv[i].GetComponent<ItemScript>().getValue(), 
                otherInv[i].GetComponent<ItemScript>().getItemType(), 
                cp.GetComponent<NPCGang>().getDesiredType(),
                cp.GetComponent<NPCGang>().getUndesiredType());

            uiItem.GetComponent<ItemUIScript>().initUI(otherInv[i].name, price,
                otherInv[i].GetComponent<ItemScript>().getIcon());
        }
    }

    int editPrice(int price, int itemType, int desiredType, int dislikedType)
    {
        if(itemType == desiredType)
        {
            price += 3;
        }
        if(itemType == dislikedType)
        {
            price -= 3;
        }
        return price;
    }

    //Called on Button
    public void swapItems()
    {
        List<int> playerTrades = new List<int>();
        List<int> otherTrades = new List<int>();
        int pTotal = 0, oTotal = 0;
        //Swap item indexes
        for(int i=0;i<playerUI.Count; i++)
        {
            if (playerUI[i].GetComponent<ItemUIScript>().isChosen())
            {
                playerTrades.Add(playerUI[i].GetComponent<ItemUIScript>().invIndex);
                pTotal += playerUI[i].GetComponent<ItemUIScript>().value;
            }
        }

        for (int i = 0; i < otherUI.Count; i++)
        {
            if (otherUI[i].GetComponent<ItemUIScript>().isChosen())
            {
                otherTrades.Add(otherUI[i].GetComponent<ItemUIScript>().invIndex);
                oTotal += otherUI[i].GetComponent<ItemUIScript>().value;
            }
        }
        if(pTotal >= (oTotal - acceptedValueDifference))
        {
            //Make Swap
            //Add to inventories
            Debug.Log("Player Trades: " + playerTrades.Count);
            Debug.Log("Other Trades: " + otherTrades.Count);

            for(int i = 0; i < playerTrades.Count; i++)
            {
                otherInv.Add(playerInv[playerTrades[i]]);
            }
            for (int i = 0; i < otherTrades.Count; i++)
            {
                playerInv.Add(otherInv[otherTrades[i]]);
            }
            //Remove from inventories
            for (int i = playerTrades.Count; i > 0; i--)
            {
                playerInv.RemoveAt(playerTrades[i-1]);
            }
            for (int i = otherTrades.Count-1; i >= 0; i--)
            {
                otherInv.RemoveAt(otherTrades[i]);
            }
        }
        else
        {
            //Tell player to fuck off i dont trust like that
            Debug.Log("Offer to give more");
        }
        playerTrades.Clear();
        otherTrades.Clear();
        //Clear Screen
        clearUI();

        //redisplay inventory
        displayInventory();
    }

    //Called on Button
    public void exitTrade()
    {
        tradeButton.SetActive(false);
        exitButton.SetActive(false);
        //Set player movement active
        player.GetComponent<PlayerMovement>().inTrade = false;

        //Return new inventories back to respective holders
        player.GetComponent<InventoryScript>().returnInv(playerInv);
        cp.GetComponent<InventoryScript>().returnInv(otherInv);

        //Delete UI Elements
        for (int i = 0; i < playerUI.Count; i++)
        {
            Destroy(playerUI[i]);
        }
        for (int i = 0; i < otherUI.Count; i++)
        {
            Destroy(otherUI[i]);
        }

    }

    void clearUI()
    {
        for (int i = 0; i < playerUI.Count; i++)
        {
            Destroy(playerUI[i]);
        }
        for (int i = 0; i < otherUI.Count; i++)
        {
            Destroy(otherUI[i]);
        }
        playerUI.Clear();
        otherUI.Clear();
    }
}
