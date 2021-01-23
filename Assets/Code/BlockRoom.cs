using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRoom : MonoBehaviour
{
    public GameObject Barrior;
    public GameObject Barrior2;
    public GameObject[] EnemyTraget;
    public int enemyIndex = 0;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyTraget[enemyIndex] == null)
        {
            enemyIndex += 1;
        }
        else if (EnemyTraget[enemyIndex] != null)
        {
            enemyIndex = 0;
        }

        if (enemyIndex == 9 && EnemyTraget[9] == null)
        {
            Barrior.SetActive(false);
            Barrior2.SetActive(false);

            Destroy(this);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == ("Player")))
        {
            Barrior.SetActive(true);
            Barrior2.SetActive(true);
        }
    }
}
