using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnyIdle : StateMachineBehaviour
{

    [SerializeField] private float timeUntilBored;
    private bool isBored;
    private float idleTime;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle(animator);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!isBored)
        {
            idleTime += Time.deltaTime;

            if (idleTime > timeUntilBored)
            {
                isBored = true;
                animator.SetBool("Bored", true);
            }

        }
        else if(stateInfo.normalizedTime % 1 > .98)
        {
            ResetIdle(animator);
        }
    }

    private void ResetIdle(Animator animator)
    {
        isBored = false;
        idleTime = 0;
        animator.SetBool("Bored", false);
    }
}
