using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMini_HP : MonoBehaviour
{
    public float HP;
    public float MaxHP;

    public GameObject HPB;
    public Image HPBar;
    public bool TakeHit;

    public bool isIFlame;
    public float IFlameTime;

    void Start()
    {
        HP = MaxHP;
    }

    public void TakeDamage(float amount)
    {
        if (isIFlame)
        {
            return;
        }

        if (TakeHit)
        {
            IFlameTime = 0;
            IFlameTime += Time.deltaTime;
            if(IFlameTime >= 2)
            {
                TakeHit = false;
            }
        }
        else
        {
            SoundManagerScript.PlaySound(SoundManagerScript.enemyTakeDamage);
            HP -= amount;
            SetHPBar();
            TakeHit = true;
        }
    }

    public void SetHPBar()
    {
        HPBar.fillAmount = HP / MaxHP;
    }
}
