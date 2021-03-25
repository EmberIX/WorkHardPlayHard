using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecretLevel : MonoBehaviour
{
    public bool isLevelLock;
    public string level;
    public float LevelProgress;
    public int unlockLevel;

    public Animator ani;

    public Text textShow;
    public GameObject textbox;
    ItemTrack IT;
    ChangeScene Cs;
    PlayerScript Ps;
    DayEvent DE;
    public GameObject ConfirmMenu;

    void Start()
    {
        IT = GameObject.FindObjectOfType<ItemTrack>();
        Cs = GameObject.FindObjectOfType<ChangeScene>();
        Ps = GameObject.FindObjectOfType<PlayerScript>();
        DE = GameObject.FindObjectOfType<DayEvent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Ps != null)
        {
            if (Ps.itemUse == "WHPHdrive")
            {
                isLevelLock = false;
            }
            else
            {
                isLevelLock = true;
            }

            if (isLevelLock)
            {
                ani.SetTrigger("Off");
            }
            else
            {
                ani.SetTrigger("On");
            }
        }
    }

    public void levelSelect()
    {
        if (!isLevelLock && DE.time != 0)
        {
            ConfirmMenu.SetActive(true);
            Cs.LevelToLoad = level;
        }

        if (DE.time == 0)
        {
            textShow.text = "Too early to sleep!!";
            textbox.SetActive(false);
            textbox.SetActive(true);
        }
    }
    public void Leave()
    {
        Ps.SavePlayer();
        IT.SaveData();
        Cs.LoadScene(Cs.LevelToLoad);
    }
    public void Resume()
    {
        ConfirmMenu.SetActive(false);

        return;
    }
}
