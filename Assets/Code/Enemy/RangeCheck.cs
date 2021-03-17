using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeCheck : MonoBehaviour
{
    public smallBug sB;
    public Trap tr;
    public BigSlimeScript BSS;
    public Slime_Boss B;
    public bool isCloseRange;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == ("Player")) && this.tag == ("RangeCheck"))
        {
            if (sB != null)
            {
                sB.isRange = true;
            }
            if (tr != null)
            {
                tr.isRange = true;
            }
            if (BSS != null)
            {
                BSS.isRange = true;
            }
            if (B != null)
            {
                B.isRange = true;
            }

        }
        if ((collision.tag == ("Player")) && this.tag == ("SightCheck"))
        {
            if (sB != null)
            {
                sB.isSight = true;
            }
            if (BSS != null)
            {
                BSS.isSight = true;
            }
            if (B != null)
            {
                B.isSight = true;
                B.E_H.HPB.SetActive(true);
            }
        }

        if((collision.tag == ("Player")) && isCloseRange)
        {
            if (BSS != null)
            {
                BSS.closeRange = true;
            }
            if (B != null)
            {
                B.closeRange = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.tag == ("Player")) && this.tag == ("RangeCheck"))
        {
            if (sB != null)
            {
                sB.isRange = false;
            }
            if (tr != null)
            {
                tr.isRange = false;
            }
            if (BSS != null)
            {
                BSS.isRange = false;
            }
            if (B != null)
            {
                B.isRange = false;
            }
        }

        if ((collision.tag == ("Player")) && isCloseRange)
        {
            if (BSS != null)
            {
                BSS.closeRange = false;
            }
            if (B != null)
            {
                B.closeRange = false;
            }
        }

        //if ((collision.tag == ("Player")) && this.tag == ("SightCheck"))
        //{
        //    sB.isSight = false;
        //}
    }
}
