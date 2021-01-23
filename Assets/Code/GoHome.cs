using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHome : MonoBehaviour
{
    PlayerScript Ps;
    public GameObject ConfirmMenu;
    ChangeScene Cs;
    public string home;
    public GameObject E;
    FinishLevel FL;

    public bool isAtPosition;
    public bool isOpenMenu = false;
    void Start()
    {
        Cs = GameObject.FindObjectOfType<ChangeScene>();
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        FL = GameObject.FindObjectOfType<FinishLevel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpenMenu)
        {
            if (Input.GetKeyDown("e"))
            {
                isOpenMenu = false;
                ConfirmMenu.SetActive(false);

                Ps.isInteracted = false;
                E.SetActive(true);
                return;

            }
        }

        if (isAtPosition)
        {

            if (Input.GetKeyDown("e") && isOpenMenu == false)
            {
                if (this.tag == "EndBed")
                {
                    E.SetActive(false);
                    FL.LevelEnd();
                }
                else if ((this.tag != "EndBed"))
                {
                    E.SetActive(false);
                    isOpenMenu = true;
                    ConfirmMenu.SetActive(true);
                    Ps.isInteracted = true;
                }
            }
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
        if (collision.tag == ("Player"))
        {

            isAtPosition = false;
            E.SetActive(false);

        }
    }

    public void Leave()
    {
        FL.LevelEnd();
        SoundManagerScript.clickButton();
    }

    public void Resume()
    {
        isOpenMenu = false;
        ConfirmMenu.SetActive(false);
        SoundManagerScript.clickButton();
        Ps.isInteracted = false;
        E.SetActive(true);
        return;
    }
}
