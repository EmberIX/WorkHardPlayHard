using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StartGame : MonoBehaviour
{
    PlayerScript PS;
    ItemTrack IT;
    ChangeScene CS;

    public GameObject CutScene;
    public GameObject ContineButton;
    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        IT = GameObject.FindObjectOfType<ItemTrack>();
        CS = GameObject.FindObjectOfType<ChangeScene>();

        string path = Application.persistentDataPath + "/itemS.Save";
        if (File.Exists(path))
        {

        }
        else
        {
            ContineButton.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void newGame()
    {
        PS.SavePlayer();
        IT.SaveData();

        Instantiate(CutScene, transform.position, Quaternion.identity);
    }

    public void Continue()
    {
        CS.LoadScene("LivingRoom");
    }
}
