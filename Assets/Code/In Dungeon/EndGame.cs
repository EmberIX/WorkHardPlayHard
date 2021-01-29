using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    PlayerScript PS;
    ItemTrack IT;
    public GameObject EndScene1;
    public GameObject EndScene2;
    ChangeScene Cs;
    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        IT = GameObject.FindObjectOfType<ItemTrack>();
        Cs = GameObject.FindObjectOfType<ChangeScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IT.workList.Count == 18)
        {
            EndScene1.SetActive(true);
            PS.isInteracted = true;
        }

        if(PS.date == 16 && IT.workList.Count < 18)
        {
            EndScene2.SetActive(true);
            PS.isInteracted = true;
        }
    }

    public void Finish()
    {
        PS.SavePlayer();
        IT.SaveData();
        Cs.LoadScene("MainScene");
    }
}
