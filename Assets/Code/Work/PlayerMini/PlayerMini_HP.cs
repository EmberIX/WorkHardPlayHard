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

    private void FixedUpdate()
    {
        if (TakeHit)
        {
            IFlameTime += Time.deltaTime;
            if (IFlameTime >= 2)
            {
                IFlameTime = 0;
                TakeHit = false;
            }
        }
    }

    public void TakeDamage(float amount)
    {
        print("TakeDamage");
        if (isIFlame)
        {
            return;
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
