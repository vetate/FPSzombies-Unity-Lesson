using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform player;
    public int HP = 100;
    public Animator animator;
    private EnemyHealth enemyHealth; // Reference to the EnemyHealth script
    
    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>(); // Get the EnemyHealth component attached to the same GameObject
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if (HP <= 10)
        {
            animator.SetTrigger("die");
            shouldLookAtPlayer = false;
        }
        else
        {
            animator.SetTrigger("damage");
        } 
    }

    private bool shouldLookAtPlayer = true;

    void Update()
    {
        if (shouldLookAtPlayer && !enemyHealth.isEnemyDead) // Check if the enemy should look at the player and if it's not dead
    {
        transform.LookAt(player);
    }
    }
}