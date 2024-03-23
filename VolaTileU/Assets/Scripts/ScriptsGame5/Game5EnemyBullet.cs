using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5EnemyBullet : Game5Bullet
{
    public static float enemyBulletSpeed = 10.0f;
    Rigidbody2D bulletRb;

    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>(); // Gets the rigidbody of the newly created bullet
        bulletRb.constraints = RigidbodyConstraints2D.FreezeRotation; // Freezes the rotation
    }

    void Update()
    {
        BulletMovement();
        
    }
    

    public void BulletMovement()
    {
        bulletRb.velocity = transform.up * enemyBulletSpeed; // Sets the velocity (Fires in the direction the spawn point is facing)   
    }
}
