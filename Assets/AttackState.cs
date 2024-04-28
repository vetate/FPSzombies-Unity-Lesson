using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{

Transform player;
    PlayerHealth playerHealth; // Reference to PlayerHealth script
    public int damageAmount = 10; // Amount of damage enemy deals to player

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>(); // Get PlayerHealth script component
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 2f)
            animator.SetBool("isAttacking", false);
        else
            AttackPlayer(); // Call the method to attack the player if in range
    }

    // Method to attack the player
    void AttackPlayer()
    {
        // Deal damage to player
        playerHealth.PlayerTakeDamage(damageAmount);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
