using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5Shooter : Game5Enemy
{

    // Bullet movement variables

        // Prefab / Spawnpoint Variables
        public GameObject bulletPrefab;
        public Transform game5Shooter;

        // Firing related variables
        private float bulletSpeed = 10.0f;
        private float shotDelay = 0.3f;
        private float lastShotFired;
        private Vector3 spawnPointOffset = new Vector3(0, 1, 0);
        
        

    protected override void Attack()
    {
        float timeSinceLastFired = Time.time - lastShotFired; // Calculates the time since the last bullet was fired

            // If the delay is over
            if(timeSinceLastFired >= shotDelay)
            {
                FireBullet();

                lastShotFired = Time.time;
            }
    }

    // Creates the bullets
    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, game5Shooter.position, game5Shooter.rotation); // Creates the instance of the prefab
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>(); // Gets the rigidbody of the newly created bullet

        bulletRb.velocity = transform.up * bulletSpeed; // Sets the velocity (Fires in the direction the spawn point is facing)
    }
}
