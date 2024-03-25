using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5BulletCollision : MonoBehaviour
{
    // Bullet Collision Variables

    public static float bulletLife = 3.0f / TimeManager.slowMotionMultiplier; // Time the bullet is alive for
    public static float bulletSpeed = 10.0f;
    private float damage = 2.5f;
    protected Rigidbody2D bulletRb;


    // Called when the object is initialised
    void Awake()
    {
        Destroy(gameObject, bulletLife); // Destroys the bullet after its time is up
        bulletRb = GetComponent<Rigidbody2D>(); // Gets the rigidbody of the newly created bullet
    }

    void FixedUpdate()
    {
        BulletMovement();
    }

    protected virtual void BulletMovement()
    {
        bulletRb.velocity = transform.up * bulletSpeed; // Sets the velocity (Fires in the direction the spawn point is facing)
    }


    // Destroys the enemy and the bullet if they collide
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Game5Enemy>(); // Reference to the Game5Enemy script on the collided enemy prefab // COULD CHANGE TO A TAG SYSTEM
        var enemyBullet = collision.GetComponent<Game5EnemyBullet>();
        
        // If the bullet collides with an enemy delete the bullet and deal damage
        if(enemy)
        {
            Destroy(gameObject); // Destroys the bullet
            enemy.TakeDamage(damage); // Calls the TakeDamage method in the Game5Enemy script
        }

        // Collides with enemy bullet (reverse functionality in enemy bullet child script)
        else if(enemyBullet)
        {
            Destroy(gameObject);
        }
    }
}
