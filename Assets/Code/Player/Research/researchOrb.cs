using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class researchOrb : MonoBehaviour
{
    CounterBullet CB;
    public Image I;
    void Start()
    {
        CB = GameObject.FindObjectOfType<CounterBullet>();
    }

    // Update is called once per frame
    void Update()
    {
        I.fillAmount = CB.CounterCooldown / CB.StartCounterCooldown;
    }
}
