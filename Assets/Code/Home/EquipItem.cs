using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    public string itemName;
    public ItemTrack IT;
    public PlayerScript PS;
    public GameObject sprite;
    public GameObject Lock;
    public GoDimension GD;

    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        IT = GameObject.FindObjectOfType<ItemTrack>();
        GD = GameObject.FindObjectOfType<GoDimension>();
        if (PS.itemUse == itemName)
        {
            sprite.SetActive(true);
        }
        else if (PS.itemUse != itemName)
        {
            sprite.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(IT.itemList.Contains(itemName))
        {
            Lock.SetActive(false);
        }

        if (sprite != null)
        {
            if (PS.itemUse != itemName)
            {
                sprite.SetActive(false);
            }
            if (PS.itemUse == itemName)
            {
                sprite.SetActive(true);
            }
        }
    }

    public void setItem()
    {
        PS.itemUse = itemName;

        GameObject.FindGameObjectWithTag("itemSprite").SetActive(false);

        if (PS.itemUse != itemName)
        {
            sprite.SetActive(false);
            return;
        }
        if (PS.itemUse == itemName)
        {
            sprite.SetActive(true);
        }

        GD.TurnItemMenu();
    }

}
