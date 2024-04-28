using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 100;
    public int playerHealth;
    private Transform spawnPoint;
private Transform playerPos;

    void Start()
    {
        playerHealth = maxHealth;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    public void PlayerTakeDamage(int damage)
    {
        playerHealth = playerHealth - damage;
        
        // Check if player is dead
       if (playerHealth <= 0) {

        playerHealth = maxHealth;
        playerPos.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);

        }
    }

     
}