using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer : MonoBehaviour
{
    public GameObject DesktopMenu;
    public GameObject ShopMenuu;
    public GameObject WorkMenuu;
    public GameObject MailMenuu;
    public GameObject E;
    public Text date;
    public Text dateShow;
    public bool DesktopOn;
    public bool isAtPosition;
    public bool isWorking;

    public float energy;
    public Text showEnergy;
    PlayerScript PS;

    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        energy = PS.energy;
        date.text = "" + PS.date;
        dateShow.text = "Day " + PS.date;
    }

    // Update is called once per frame
    void Update()
    {
        if (PS != null)
        {
            showEnergy.text = "Energy " + energy + "/" + PS.energy;

            if (Input.GetKeyDown("p"))
            {
                energy = 5000;
            }

            if (DesktopOn && (isWorking == false))
            {
                if (Input.GetKeyDown("e"))
                {
                    DesktopOn = false;
                    DesktopMenu.SetActive(false);
                    PS.isInteracted = false;
                    E.SetActive(true);
                    return;

                }
            }

            if (isAtPosition)
            {
                if (Input.GetKeyDown("e") && DesktopOn == false)
                {
                    PS.SavePlayer();
                    E.SetActive(false);
                    SoundManagerScript.clickButton();
                    DesktopOn = true;
                    DesktopMenu.SetActive(true);
                    PS.isInteracted = true;
                    return;
                }
            }
        }
    }

    public void OpenShop()
    {
        if(ShopMenuu.activeSelf == false)
        {
            ShopMenuu.SetActive(true);
            return;
        }

        if(ShopMenuu.activeSelf == true)
        {
            ShopMenuu.SetActive(false);
            return;
        }
    }

    public void OpenWork()
    {
        if (WorkMenuu.activeSelf == false)
        {
            WorkMenuu.SetActive(true);
            return;
        }
        
        if (WorkMenuu.activeSelf == true)
        {
            WorkMenuu.SetActive(false);
            return;
        }
    }

    public void OpenMail()
    {
        if (MailMenuu.activeSelf == false)
        {
            MailMenuu.SetActive(true);
            return;
        }

        if (MailMenuu.activeSelf == true)
        {
            MailMenuu.SetActive(false);
            return;
        }
    }

    public void CloseComputer()
    {
        DesktopOn = false;
        DesktopMenu.SetActive(false);
        PS.isInteracted = false;
        E.SetActive(true);
        return;
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
        if (collision.tag == ("Player"))
        {

            isAtPosition = false;
            E.SetActive(false);

        }
    }

}
