using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalDoor : MonoBehaviour
{
    PlayerScript Ps;
    ChangeScene Cs;
    public GameObject E;
    public string level;
    public int unlockLevel;
    public GameObject textBox;
    public Text text;
    public GameObject ParticalDoor;

    public bool isAtPosition;
    public bool isOpenMenu = false;
    void Start()
    {
        Cs = GameObject.FindObjectOfType<ChangeScene>();
        Ps = GameObject.FindObjectOfType<PlayerScript>();

        if (Ps.progress >= unlockLevel)
        {
            ParticalDoor.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (isOpenMenu)
        //{
        //    if (Input.GetKeyDown("e"))
        //    {
        //        isOpenMenu = false;
        //        ConfirmMenu.SetActive(false);

        //        Ps.isInteracted = false;
        //        E.SetActive(true);
        //        Time.timeScale = 1f;
        //        return;

        //    }
        //}

        //if (isAtPosition)
        //{
        //    if (Input.GetKeyDown("e") && isOpenMenu == false)
        //    {
        //        E.SetActive(false);
        //        isOpenMenu = true;
        //        ConfirmMenu.SetActive(true);
        //        Ps.isInteracted = true;
        //        Time.timeScale = 0f;
        //    }
        //}
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            //isAtPosition = true;
            //E.SetActive(true);

            if (Ps.progress < unlockLevel)
            {
                Ps.progress = unlockLevel;
                Ps.exp += 5;
                ParticalDoor.SetActive(true);
                textBox.SetActive(false);
                text.text = "Progress Update!";
                textBox.SetActive(true);
            }

            //Instantiate(ParticalDoor, transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == ("Player"))
        {

            //isAtPosition = false;
            //E.SetActive(false);

        }
    }

    public void Leave()
    {
        Ps.SavePlayer();
        Cs.LoadScene(level);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isOpenMenu = false;
        //ConfirmMenu.SetActive(false);

        Ps.isInteracted = false;
        E.SetActive(true);
        return;

    }
}
