using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkEngine : MonoBehaviour
{

    public Work choosenWork;
    Enemy_HP EH;
    Timer T;
    PlayerMini_HP PM_H;

    void Start()
    {
        EH = GetComponentInChildren<Enemy_HP>();
        T = GetComponentInChildren<Timer>();
        PM_H = GetComponentInChildren<PlayerMini_HP>();


    }

    void Update()
    {
        if(EH.HP <= 0 )
        {
            print("Work Success");
            choosenWork.WorkSuccess();
        }

        if((T.timeLeft <= 0)||(PM_H.HP <= 0))
        {
            print("Work Fail");
            choosenWork.WorkFail();
        }
    }
}
