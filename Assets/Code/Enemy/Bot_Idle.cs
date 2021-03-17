using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Idle : StateMachineBehaviour
{
    int random;
    int pRandom;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        random = Random.Range(1, 4);
        while (random == pRandom)
            random = Random.Range(1, 4);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Bot_Boss B_B = Animator.FindObjectOfType<Bot_Boss>();

        B_B.prepareAttack(1, "Attack" + random);
        pRandom = random;
    
        Boss_HP B_H = Animator.FindObjectOfType<Boss_HP>();
        if(B_H.HP <= B_H.MaxHP/2)
        {
            animator.SetBool("State2", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
