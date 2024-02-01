using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5BulletCollision : MonoBehaviour
{
    // Bullet Collision Variables

    public float life = 3.0f; // Time the bullet is alive for

    // Called when the object is initialised
    void Awake()
    {
        Destroy(gameObject, life); // Destroys the bullet after its time is up
    }

    // Destroys the enemy and the bullet if they collide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Game5EnemyMovement>())
        {
            Destroy(collision.gameObject); // Destroys the enemy
            Destroy(gameObject); // Destroys the bullet
        } 
    }
}
