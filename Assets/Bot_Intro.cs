using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Intro : StateMachineBehaviour
{

    Boss_HP B_H;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        B_H = Animator.FindObjectOfType<Boss_HP>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        B_H.isIFlame = true;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        B_H.BeginrFight();
    }


}
