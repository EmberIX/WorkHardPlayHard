using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyBugRangeCheck : MonoBehaviour
{
    public SummonBug SB;
    public BlueSlimeScript BSS;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ((collision.tag == ("Boss") || collision.tag == ("Bot_Boss") || collision.tag == ("BigSlime") || collision.tag == ("Enemy") || collision.tag == ("smallBug") && this.tag == ("RangeCheck")))
        {
            if (SB != null)
            {
                SB.isRange = true;
                SB.Target = collision.gameObject.transform;
            }
            if( BSS != null)
            {
                BSS.isRange = true;
                BSS.Target = collision.gameObject.transform;
            }
        }

        if ((collision.tag == ("Boss") || collision.tag == ("Bot_Boss") ||  collision.tag == ("BigSlime") || collision.tag == ("Enemy")) || collision.tag == ("smallBug") && this.tag == ("SightCheck"))
        {
            if (SB != null)
            {
                SB.isSight = true;
            }

            if (BSS != null)
            {
                BSS.isSight = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((collision.tag == ("Boss") || collision.tag == ("Bot_Boss") || collision.tag == ("BigSlime") || collision.tag == ("Enemy")) || collision.tag == ("smallBug") && this.tag == ("RangeCheck"))
        {
            if (SB != null)
            {
                SB.isRange = false;
            }

            if (BSS != null)
            {
                BSS.isRange = false;
            }
        }

        if ((collision.tag == ("Boss") || collision.tag == ("Bot_Boss") || collision.tag == ("BigSlime") || collision.tag == ("Enemy")) || collision.tag == ("smallBug") && this.tag == ("SightCheck"))
        {
            if (SB != null)
            {
                SB.isSight = false;
            }
            if (BSS != null)
            {

            }
        }

    }
}
