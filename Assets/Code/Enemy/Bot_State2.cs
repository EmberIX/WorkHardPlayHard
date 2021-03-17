using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_State2 : StateMachineBehaviour
{
    int random;
    int pRandom;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        random = Random.Range(4, 7);
        while (random == pRandom)
            random = Random.Range(4, 7);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Bot_Boss B_B = Animator.FindObjectOfType<Bot_Boss>();

        B_B.prepareAttack(0.6f, "Attack" + random);
        pRandom = random;

        Enemy_HP B_H = Animator.FindObjectOfType<Bot_Boss>().B_H;
        if (B_H.HP <= 0)
        {
            animator.SetBool("Dying", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
