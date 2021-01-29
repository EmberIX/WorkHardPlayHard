using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    PlayerScript PS;
    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PS.HP < PS.MaxHP)
        {
            StartCoroutine(Wait());
            IEnumerator Wait()
            {
                yield return new WaitForSeconds(0.7f);
                if (PS.HP < PS.MaxHP)
                {
                    PS.HP++;
                    PS.SetHPBar();
                }
            }
        }
    }
}
