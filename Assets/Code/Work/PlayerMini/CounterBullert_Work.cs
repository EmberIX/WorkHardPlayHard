using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterBullert_Work : MonoBehaviour
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
    //public GameObject Bullet;

    public GameObject[] UI;
    PlayerMini PM;
    void Start()
    {
        PM = GameObject.FindObjectOfType<PlayerMini>();


        bulletKeep = KeepMax;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < UI.Length; i++)
        {
            if (i < bulletKeep)
            {
                UI[i].SetActive(true);
            }
            else
            {
                UI[i].SetActive(false);
            }
        }

        if (Input.GetKeyDown("e") && CounterCooldown <= 0 && (bulletKeep > 0))
        {
            isCounter = true;
            CounterTime = 0;
            SoundManagerScript.PlaySound(SoundManagerScript.spear);
            ParticleSystem ShieldShow = Instantiate(Shield, transform.position, Quaternion.identity);
            ShieldShow.transform.SetParent(GameObject.FindGameObjectWithTag("Canvas_Work").transform);
        }

        if (isCounter)
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
                print("Keep!");
                if (bulletKeep > 0)
                {
                    bulletKeep -= 1;
                    SoundManagerScript.PlaySound(SoundManagerScript.Research);
                    Destroy(collision.gameObject);
                    Instantiate(TakeBullet, transform.position, Quaternion.identity);
                    //Instantiate(Bullet, transform.position, Quaternion.identity);
                }
            }
        }
    }
}