using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingOrb : MonoBehaviour
{
    public PlayerScript PS;
    public GameObject healingPar;
    void Start()
    {
        PS = GameObject.FindObjectOfType<PlayerScript>();
        if (PS.itemUse != "healingOrb")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown("q")))
        {
            PS.HP += PS.MaxHP / 2;
            Instantiate(healingPar, transform.position, Quaternion.identity);
            if (PS.HP > PS.MaxHP)
            {
                SoundManagerScript.PlaySound(SoundManagerScript.heal);
                PS.HP = PS.MaxHP;
            }

            Destroy(this.gameObject);
        }
    }
}
