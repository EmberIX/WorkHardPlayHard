using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smallBugAttacking : MonoBehaviour
{
    public smallBug sB;
    void Start()
    {
        
    }

    public void finishAttack()
    {
        print("Attack");
        sB.Attack();
    }
}
