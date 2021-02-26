using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Idle : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Bot_Boss B_B = Animator.FindObjectOfType<Bot_Boss>();
        B_B.prepareAttack(3);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
