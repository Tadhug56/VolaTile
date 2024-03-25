using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5EnemyBullet : Game5BulletCollision
{
    
    public static float enemyBulletSpeed = 10.0f;
    

    // METHODS

    protected override void BulletMovement()
    {
        bulletRb.velocity = transform.up * enemyBulletSpeed; // Sets the velocity (Fires in the direction the spawn point is facing)
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        
        var player = collision.GetComponent<Game5Bullet>();
        var playerBullet = collision.GetComponent<Game5BulletCollision>();
        
        // If the bullet collides with the players bullet delete the bullet
        if(player)
        {
            Destroy(gameObject); // Destroys the bullet
            // Take Damage
        }

        else if(playerBullet)
        {
            Destroy(gameObject);
        }
    }
}
