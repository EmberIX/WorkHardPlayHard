using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeMax;
    public float timeLeft;
    public Image timerBar;
    Enemy_HP workHP;
    public GameObject success;
    public PlayerMini_HP PMH;
    void Start()
    {
        timeLeft = timeMax;
        workHP = GetComponentInParent<Enemy_HP>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeLeft > 0 && workHP.HP > 0)
        {
            timeLeft -= Time.deltaTime;
            SetTimer();
        }
        else if(workHP.HP <= 0)
        {
            //TimerStop();
        }
        else
        {
            TimeOut();
            PMH.TakeDamage(PMH.HP);
        }
    }

    void SetTimer()
    {
        timerBar.fillAmount = timeLeft / timeMax;
    }

    void TimeOut()
    {
        print("TimeOut");
    }

    void TimerStop()
    {
        success.SetActive(true);
    }
}
