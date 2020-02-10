using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public int walletAmount;
    public List<GameObject> items = new List<GameObject>();

    public int getWalletAmount()
    {
        return walletAmount;
    }

    public void addToWallet(int income)
    {
        walletAmount += income;
    }

    public GameObject getItem(int index)
    {
        return items[index];
    }

    public void removeItem(int index)
    {
        items.RemoveAt(index);
    }

    public void addItem(GameObject item)
    {
        items.Add(item);
    }

    public List<GameObject> getInv()
    {
        return items;
    }

    public void returnInv(List<GameObject> inventory)
    {
        //items.Clear();
        items = new List<GameObject>(inventory);
    }
}
