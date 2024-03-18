using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5EnemyBulletCollision : MonoBehaviour
{
    // Bullet Collision Variables

    public static float bulletLife = 3.0f / TimeManager.slowMotionMultiplier; // Time the bullet is alive for
    private float damage = 2.5f;


    // Called when the object is initialised
    void Awake()
    {
        Destroy(gameObject, bulletLife); // Destroys the bullet after its time is up
    }


    // Destroys the enemy and the bullet if they collide
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<Game5PlayerAttributes>(); // Reference to the Game5PlayerAttributes script on the collided player

        // If the bullet collides with the player delete the bullet and deal damage
        if(player)
        {
            Destroy(gameObject); // Destroys the bullet
            player.TakeDamage(damage); // Calls the TakeDamage method in the Game5PlayerAttributes script
        }
    }
}
