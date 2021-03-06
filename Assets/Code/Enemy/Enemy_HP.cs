﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_HP : MonoBehaviour
{
    public float HP;
    public float MaxHP;

    public GameObject HPB;
    public Image HPBar;
    public bool TakeHit;
    
    public bool isIFlame;
    public Animator ani;
    private void Start()
    {
        HP = MaxHP;
        SetHPBar();
    }

    void OnEnable()
    {
        SetHPBar();
    }

    public void TakeDamage(float amount)
    {
        if(isIFlame)
        {
            return;
        }
        SoundManagerScript.PlaySound(SoundManagerScript.enemyTakeDamage);
        HP -= amount;
        SetHPBar();
        if(ani != null)
        {
            ani.SetTrigger("takeDamage");
        }
    }

    public void SetHPBar()
    {
        HPBar.fillAmount = HP / MaxHP;
    }

    public void BeginrFight()
    {
        isIFlame = false;
        HPB.SetActive(true);
    }

}
