using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUIScript : MonoBehaviour
{

    public GameObject itemName, price, panel;
    Image icon;
    public Color highlighted;
    bool isPicked;
    public int invIndex, value;

    void Start()
    {
        icon = GetComponent<Image>();
        isPicked = false;
    }

    public bool isChosen()
    {
        return isPicked;
    }

    public void hasBeenClicked()
    {
        isPicked = !isPicked;
        Debug.Log(itemName.GetComponent<Text>().text);

        if (isPicked)
        {
            panel.GetComponent<Image>().color = highlighted;
        }
        else
        {
            panel.GetComponent<Image>().color = new Vector4(185.0f, 185.0f, 185.0f, 143.0f);
        }
    }

    public void initUI(string name, int uivalue, Sprite uiIcon)
    {
        value = uivalue;
        icon = GetComponent<Image>();
        icon.sprite = uiIcon;
        itemName.GetComponent<Text>().text = name;
        price.GetComponent<Text>().text = uivalue.ToString();
    }
}
