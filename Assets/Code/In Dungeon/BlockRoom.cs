using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRoom : MonoBehaviour
{
    public GameObject Barrior;
    public GameObject Barrior2;
    public GameObject[] EnemyTraget;
    public ParticleSystem dust;
    public int enemyIndex = 0;

    void Start()
    {
        Barrior.SetActive(false);
        Barrior2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if(EnemyTraget[enemyIndex] == null)
        //{
        //    enemyIndex += 1;
        //}
        //else if (EnemyTraget[enemyIndex] != null)
        //{
        //    enemyIndex = 0;
        //}

        //if (enemyIndex == EnemyTraget.Length)
        //{
        //    Barrior.SetActive(false);
        //    Barrior2.SetActive(false);

        //    Destroy(this);
        //}
        
        if (enemyIndex >= EnemyTraget.Length)
        {
            print("Clear");
            Barrior.SetActive(false);
            Barrior2.SetActive(false);

            Destroy(this);
        }

        for (enemyIndex = 0; EnemyTraget[enemyIndex] == null; enemyIndex++)
        {
            if (enemyIndex == EnemyTraget.Length)
            {
                break;
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == ("Player")))
        {
            Barrior.SetActive(true);
            Barrior2.SetActive(true);

            Instantiate(dust, Barrior.transform.position, Quaternion.identity);
            Instantiate(dust, Barrior2.transform.position, Quaternion.identity);
        }
    }
}
