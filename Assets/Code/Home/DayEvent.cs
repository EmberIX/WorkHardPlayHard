using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayEvent : MonoBehaviour
{
    public PlayerScript Ps;
    public int time;
    public Animator ani;

    void Start()
    {
        Ps = GameObject.FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time == 0)
        {
            Morning();
        }
        if (time == 1)
        {
            Afternoon();
        }
        if (time == 2)
        {
            Night();
        }


        if (Input.GetKeyDown("m"))
        {
            Ps.money = 2000;
        }
        if(Input.GetKeyDown("0"))
        {
            time = 0;
            Morning();
        }
        if (Input.GetKeyDown("1"))
        {
            time = 1;
            Afternoon();
        }
        if (Input.GetKeyDown("2"))
        {
            time = 2;
            Night();
        }

        if(Input.GetKeyDown("4"))
        {
            Ps.progress = 4;
        }
    }

    public void Morning()
    {
        ani.SetTrigger("Morning");
    }

    public void Afternoon()
    {
        ani.SetTrigger("Afternoon");
    }
    public void Night()
    {
        ani.SetTrigger("Night");
    }
}
