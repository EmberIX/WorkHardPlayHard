using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialyWork : MonoBehaviour
{
    PlayerScript PS;
    DayEvent DE;
    Computer C;

    public Text moneyShow; 
    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        DE = GameObject.FindObjectOfType<DayEvent>();
        C = GameObject.FindObjectOfType<Computer>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyShow.text = PS.money + " $";
    }

    public void DoWork()
    {
        if(DE.time < 2 && C.energy > 0)
        {
            PS.money += C.energy;
            C.energy = 0;
            SoundManagerScript.PlaySound(SoundManagerScript.getMoney);
            DE.time += 1;
           
        }
    }
}
