using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptShooter : MonoBehaviour
{
    Vector2 lookDirection;
    public float lookAngle;
    public Transform Shooter;
    public Transform ShooterSprite;
    public GameObject Bullet;
    public GameObject smallBullet;
    public GameObject SpecialBullet;
    public GameObject SpecialBullet2;

    public GameObject ResearchOrb;

    public float Overheat;
    public float heating;
    public GameObject Bar;
    CounterBullet CB;
    public PlayerScript PS;
    private void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        Overheat = PS.energy + 5;
        heating = Overheat;
        Bar = GameObject.FindGameObjectWithTag("noteBookBarSprite");
        SetEnegyBar();
        CB = GameObject.FindObjectOfType<CounterBullet>();

        ResearchOrb = GameObject.FindGameObjectWithTag("ResearchOrb");
    }

    void Update()
    {
        if (PS.isDead != true)
        {
            ResearchOrb = GameObject.FindGameObjectWithTag("ResearchOrb");
            if (Input.GetMouseButtonDown(0) && heating > 0)
            {
                FireBullet();
                SoundManagerScript.PlaySound(SoundManagerScript.shootBullet);
                heating -= 1.5f;
                SetEnegyBar();
            }

            if (Input.GetMouseButtonDown(0) && heating <= 0)
            {
                SoundManagerScript.PlaySound(SoundManagerScript.clickSound);
                FireSmallBullet();
            }

            if (Input.GetMouseButtonDown(1) && CB.bulletKeep < CB.KeepMax)
            {
                
                FireSpecialBullet();
                heating = Overheat;
                SetEnegyBar();
            }

            //if (heating < Overheat)
            //{
            //    heating += Time.deltaTime;
            //    SetEnegyBar();
            //}
        }
    }

    public void SetEnegyBar()
    {
        Bar.GetComponent<Image>().fillAmount = heating / Overheat;
    }

    void FireBullet()
    {
        GameObject firedBullet = Instantiate(Bullet, ShooterSprite.position, Shooter.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = Shooter.right*12f;
    }

    void FireSmallBullet()
    {
        GameObject firedBullet = Instantiate(smallBullet, ShooterSprite.position, Shooter.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = Shooter.right * 12f;
    }

    void FireSpecialBullet()
    {
        if (PS.itemUse == "noteBookMod")
        {
            Instantiate(SpecialBullet2, transform.position, Quaternion.identity);
            SoundManagerScript.PlaySound(SoundManagerScript.particleBullet);
            CB.bulletKeep += 1;
            Destroy(ResearchOrb);
        }
        else
        {
            GameObject firedBullet = Instantiate(SpecialBullet, ShooterSprite.position, Shooter.rotation);
            firedBullet.GetComponent<Rigidbody2D>().velocity = Shooter.right * 12f;
            SoundManagerScript.PlaySound(SoundManagerScript.CounterBullet);
            CB.bulletKeep += 1;
            Destroy(ResearchOrb);
        }
    }
}
