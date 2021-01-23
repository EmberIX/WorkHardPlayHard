using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDimension : MonoBehaviour
{
    PlayerScript PS;
    ItemTrack IT;
    public GameObject levelSelectMenu;
    public GameObject playerStatuaMenu;
    public GameObject E;
    public ChangeScene Cs;

    public bool isAtPosition;
    public bool isOpenMenu = false;
    public GameObject itemMenu;

    void Awake()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        IT = GameObject.FindObjectOfType<ItemTrack>();
        PS.LoadPlayer();
        IT.LoadData();
    }
    void Start()
    {
        Cs = GameObject.FindObjectOfType<ChangeScene>();
        levelSelectMenu.SetActive(false);
        playerStatuaMenu.SetActive(false);
        itemMenu.SetActive(false);
    }

    void Update()
    {

        if (isOpenMenu)
        {
            if (Input.GetKeyDown("e"))
            {
                isOpenMenu = false;
                levelSelectMenu.SetActive(false);
                playerStatuaMenu.SetActive(false);
                PS.isInteracted = false;
                E.SetActive(true);
                return;

            }
        }

        if (isAtPosition)
        {
            if (Input.GetKeyDown("e") && isOpenMenu == false )
            {
                PS.SavePlayer();
                //Cs.FinishFade();
                SoundManagerScript.clickButton();
                E.SetActive(false);
                isOpenMenu = true;
                levelSelectMenu.SetActive(true);
                playerStatuaMenu.SetActive(true);
                PS.isInteracted = true;
            }
        }
    }

    public void TurnItemMenu()
    {
        if (itemMenu.activeSelf == false)
        {
            itemMenu.SetActive(true);
        }
        else
        {
            itemMenu.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {
            isAtPosition = true;
            E.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == ("Player"))
        {

            isAtPosition = false;
            E.SetActive(false);

        }
    }
}
