using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{

float timer;
Transform player;
float chaseRange = 4;

// OnStateEnter is called when a transition starts
override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
    timer = Random.Range(3, 7);  // Generate a random timer between 3 and 7 seconds
    player = GameObject.FindGameObjectWithTag("Player").transform;
}

// OnStateUpdate is called on each Update frame
override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
{
    if (timer > 0)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            animator.SetBool("isPatrolling", true);
        }
    }

    float distance = Vector3.Distance(player.position, animator.transform.position);
    if (distance < chaseRange)
    {
        animator.SetBool("isChasing", true);
    }
}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
