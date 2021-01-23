using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBarUI : MonoBehaviour
{

    public bool isHome;

    SpearScript SS;

    ScriptShooter SShoot;

    void Start()
    {

        if (isHome == false)
        {
            SS = GameObject.FindObjectOfType<SpearScript>();
            SShoot = GameObject.FindObjectOfType<ScriptShooter>();

            if (SShoot == null)
            {
                GameObject.FindGameObjectWithTag("ShooterBar").SetActive(false);
            }

            if (SS == null)
            {
                GameObject.FindGameObjectWithTag("SpearBar").SetActive(false);
            }
        }
    }

    
    void Update()
    {
        
    }
}
