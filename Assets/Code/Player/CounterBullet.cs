using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterBullet : MonoBehaviour
{
    public bool isCounter;

    public float CounterTime;
    public float CounterEnd;
    public float CounterCooldown;
    public float StartCounterCooldown;

    public int bulletKeep = 0;
    public int KeepMax = 1;

    public ParticleSystem Shield;
    public ParticleSystem TakeBullet;
    public GameObject Bullet;

    public GameObject[] UI;
    PlayerScript PS;
    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        if(PS.itemUse == "researchTool")
        {
            KeepMax = 3;
        }
        else
        {
            KeepMax = 1;
        }

        if (PS.itemUse == "scopeTool")
        {
            StartCounterCooldown = 0.7f;
        }
        

        bulletKeep = KeepMax;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i< UI.Length; i++)
        {
            if(i < bulletKeep)
            {
                UI[i].SetActive(true);
            }
            else
            {
                UI[i].SetActive(false);
            }
        }

        if(Input.GetKeyDown("e") && CounterCooldown <= 0 && (bulletKeep > 0))
        {
            isCounter = true;
            CounterTime = 0;
            SoundManagerScript.PlaySound(SoundManagerScript.spear);
            Instantiate(Shield, transform.position, Quaternion.identity);
        }

        if(isCounter)
        {
            CounterCooldown = StartCounterCooldown;
            CounterTime += Time.deltaTime;

        }

        if (CounterTime >= CounterEnd)
        {
            isCounter = false;
            CounterCooldown -= Time.deltaTime;

            if (CounterCooldown <= 0)
            {
                CounterCooldown = 0;
                return;
            }
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isCounter)
        {
            if (collision.tag == ("EnemyBullet"))
            {
                //print("Keep!");
                if (bulletKeep > 0)
                {
                    bulletKeep -= 1;
                    SoundManagerScript.PlaySound(SoundManagerScript.Research);
                    Destroy(collision.gameObject);
                    Instantiate(TakeBullet, transform.position, Quaternion.identity);
                    Instantiate(Bullet, transform.position, Quaternion.identity);
                }
            }

            if(PS.itemUse == "scopeTool")
            {
                if (collision.tag == ("PurpleBullet"))
                {
                    if (bulletKeep > 0)
                    {
                        bulletKeep -= 1;
                        SoundManagerScript.PlaySound(SoundManagerScript.Research);
                        Destroy(collision.gameObject);
                        Instantiate(TakeBullet, transform.position, Quaternion.identity);
                        Instantiate(Bullet, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
