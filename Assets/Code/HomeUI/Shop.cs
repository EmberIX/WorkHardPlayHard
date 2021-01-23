using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    PlayerScript PS;
    ItemTrack IT;
    public GameObject BuyButton;
    public GameObject Sold;
    public string itemName;
    public int cost;
    public bool isSold;
    public Text showText;
    public GameObject TextBox;
    
    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        IT = GameObject.FindObjectOfType<ItemTrack>();

        if (IT.itemList.Contains(itemName))
        {
            isSold = true;
        }

        if (isSold)
        {
            BuyButton.SetActive(false);
            Sold.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(IT.itemList.Contains(itemName))
        {
            isSold = true;
        }

        if(isSold)
        {
            BuyButton.SetActive(false);
            Sold.SetActive(true);
        }
    }

    public void BuyItem()
    {
        if (PS.money >= cost)
        {
            SoundManagerScript.PlaySound(SoundManagerScript.butItem);
            PS.money -= cost;
            showText.text = "You have buy " + itemName;
            TextBox.SetActive(false);
            TextBox.SetActive(true);
            IT.itemList.Add(this.itemName);
            IT.SaveData();
            PS.SavePlayer();
        }
        else
        {
            showText.text = "Not enough money";
            TextBox.SetActive(false);
            TextBox.SetActive(true);
        }

    }
}
