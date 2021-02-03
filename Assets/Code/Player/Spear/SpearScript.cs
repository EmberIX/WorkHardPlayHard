using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpearScript : MonoBehaviour
{

    public Transform Shooter;
    public Transform ShooterSprite;
    public GameObject SpearAttack;
    public GameObject SpearAttackNoPower;

    public GameObject SpearAtBack;

    public bool isAttacking;
    public float StillAttack;
    public float EndAttack = 0.4f;

    public GameObject ResearchOrb;

    public GameObject SummonCalling;
    public GameObject SummonCalling2;

    public GameObject damageP;
    public float Break;
    public float Durability;
    public GameObject Bar;
    CounterBullet CB;
    PlayerMoveMent PM;
    public PlayerScript PS;

    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        Break = PS.energy;

        Durability = Break;
        Bar = GameObject.FindGameObjectWithTag("SpearBarSprite");
        SetSpearBar();
        CB = GameObject.FindObjectOfType<CounterBullet>();
        PM = GameObject.FindObjectOfType<PlayerMoveMent>();
        ResearchOrb = GameObject.FindGameObjectWithTag("ResearchOrb");
    }

    // Update is called once per frame
    void Update()
    {
        if (PS.isInteracted)
        {
            return;
        }

        if (PS.isDead != true)
        {
            PM.CurrentSpeed = 3.7f;
            ResearchOrb = GameObject.FindGameObjectWithTag("ResearchOrb");

            if (Durability >= Break)
            {
                Durability = Break;
            }

            if (Input.GetMouseButtonDown(0) && Durability > 0 )
            {
                FireSpear();
                Durability -= 1.5f;
                SetSpearBar();
                isAttacking = true;
                StillAttack = 0;
            }
            else if (Input.GetMouseButtonDown(0) && Durability <= 0)
            {
                FireSpear2();

                isAttacking = true;
                StillAttack = 0;
            }

            if (Input.GetMouseButtonDown(1) && CB.bulletKeep < CB.KeepMax && PS.itemUse!= "penMod")
            {
                Summon();
                SetSpearBar();
            }
            else if (Input.GetMouseButtonDown(1) && CB.bulletKeep < CB.KeepMax && PS.itemUse == "penMod")
            {
                Summon2();
                SetSpearBar();
            }

            if (StillAttack >= EndAttack)
            {
                isAttacking = false;
            }

            if (isAttacking)
            {
                SpearAtBack.SetActive(false);
                StillAttack += Time.deltaTime;
            }
            else if (isAttacking == false)
            {
                SpearAtBack.SetActive(true);
            }
        }
    }

    void FireSpear()
    {
        GameObject firedBullet = Instantiate(SpearAttack, ShooterSprite.position, Shooter.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = Shooter.right * 4;
        firedBullet.transform.right = Shooter.transform.right;
        SoundManagerScript.PlaySound(SoundManagerScript.spearPower);
    }

    void FireSpear2()
    {
        GameObject firedBullet = Instantiate(SpearAttackNoPower, ShooterSprite.position, Shooter.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = Shooter.right * 4;
        firedBullet.transform.right = Shooter.transform.right;
    }

    void Summon()
    {
        Instantiate(damageP, ShooterSprite.position, Quaternion.identity);
        GameObject Summon = Instantiate(SummonCalling, ShooterSprite.position, Quaternion.identity);
        CB.bulletKeep += 1;
        Destroy(ResearchOrb);
        SoundManagerScript.PlaySound(SoundManagerScript.summonBug);
    }

    void Summon2()
    {
        Instantiate(damageP, ShooterSprite.position, Quaternion.identity);
        GameObject Summon2 = Instantiate(SummonCalling2, ShooterSprite.position, Quaternion.identity);
        CB.bulletKeep += 1;
        Destroy(ResearchOrb);
        SoundManagerScript.PlaySound(SoundManagerScript.summonBug);
    }

    public void SetSpearBar()
    {
        Bar.GetComponent<Image>().fillAmount = Durability / Break;
    }
}
