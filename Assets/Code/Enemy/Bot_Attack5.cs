using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot_Attack5 : StateMachineBehaviour
{
    GameObject shootPortal;
    GameObject shootPortal2;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Bot_Boss B_B = Animator.FindObjectOfType<Bot_Boss>();
        shootPortal = Instantiate(B_B.shooterPortal, B_B.shooterA.position, Quaternion.identity);
        shootPortal2 = Instantiate(B_B.shooterPortal, B_B.shooterB.position, Quaternion.identity);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Bot_Boss B_B = Animator.FindObjectOfType<Bot_Boss>();
        shootPortal.transform.parent = B_B.shooterA;
        shootPortal2.transform.parent = B_B.shooterB;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(shootPortal);
        Destroy(shootPortal2);
        animator.SetBool("Attack5", false);
    }
}
