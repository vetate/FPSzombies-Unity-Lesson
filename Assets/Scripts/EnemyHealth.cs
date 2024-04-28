using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int currentHealth = 20;
    public bool isEnemyDead = false;



    public void TakeDamage(int damage)
{
        currentHealth = currentHealth - damage;
        // Play the damage animation which is named Scream
        gameObject.GetComponent<Animator>().Play("Scream");

        if (currentHealth <= 0 && isEnemyDead == false)
        {

        Debug.Log("DEAD: " + currentHealth);
        gameObject.GetComponent<Animator>().Play("Dying");
        isEnemyDead = true;
        GetComponent<Collider>().enabled = false;

        }

}
 
   
}
