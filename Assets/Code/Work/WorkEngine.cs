using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkEngine : MonoBehaviour
{

    public Work choosenWork;
    Enemy_HP EH;
    Timer T;
    PlayerMini_HP PM_H;
    
    public Animator ani;
    public Animator WorkAni;
    public Animator PlayerAni;

    void Start()
    {
        EH = GetComponentInChildren<Enemy_HP>();
        T = GetComponentInChildren<Timer>();
        PM_H = GetComponentInChildren<PlayerMini_HP>();

    }

    void LateUpdate()
    {
        if(EH.HP <= 0 )
        {
            WorkAni.SetTrigger("Shake");
            ani.SetTrigger("Success");
            StartCoroutine(Wait());
            IEnumerator Wait()
            {
                print("Work Success");
                yield return new WaitForSeconds(2);
                choosenWork.WorkSuccess();
            }

        }

        if((T.timeLeft <= 0)||(PM_H.HP <= 0))
        {
            print("Work Fail");
            WorkAni.SetTrigger("PlayerLose");

            ani.SetTrigger("Fail");
            StartCoroutine(Wait2());
            IEnumerator Wait2()
            {
                yield return new WaitForSeconds(2);
                choosenWork.WorkFail();
                T.timeLeft = T.timeMax;
                EH.HP = EH.MaxHP;
                PM_H.HP = PM_H.MaxHP;
            }
        }
    }
}
