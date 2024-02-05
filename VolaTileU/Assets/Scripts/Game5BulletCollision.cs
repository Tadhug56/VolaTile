using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5BulletCollision : MonoBehaviour
{
    // Bullet Collision Variables

    private float bulletLife = 3.0f; // Time the bullet is alive for
    private float damage = 2.5f;


    // Called when the object is initialised
    void Awake()
    {
        Destroy(gameObject, bulletLife); // Destroys the bullet after its time is up
    }


    // Destroys the enemy and the bullet if they collide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Game5Enemy>(); // Reference to the Game5Enemy script on the collided enemy prefab
        //if(collision.GetComponent<Game5EnemyMovement>())

        // If the bullet collides with an enemy delete the bullet and deal damage
        if(enemy)
        {
            Destroy(gameObject); // Destroys the bullet
            enemy.TakeDamage(damage); // Calls the TakeDamage method in the Game5Enemy script
        } 
    }
}
