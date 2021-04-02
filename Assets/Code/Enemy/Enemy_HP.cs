using System.Collections;
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
    private void Start()
    {
        HP = MaxHP;
    }

    public void TakeDamage(float amount)
    {
        if(isIFlame)
        {
            return;
        }
        Debug.Log("Ahhhh");
        SoundManagerScript.PlaySound(SoundManagerScript.enemyTakeDamage);
        HP -= amount;
        SetHPBar();
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
