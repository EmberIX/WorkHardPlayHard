using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MailMenu : MonoBehaviour
{
    PlayerScript PS;

    public GameObject[] inboxDay;
    public Text date;
    public GameObject mailShow;
    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        date.text = PS.date + "/12 Inbox";

        inboxDay[PS.date].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMail(GameObject Mail)
    {
        if (mailShow != null)
        {
            mailShow.SetActive(false);
        }

        mailShow = Mail;

        if (mailShow != null)
        {
            mailShow.SetActive(true);
            SoundManagerScript.clickButton();
        }
    }
}
