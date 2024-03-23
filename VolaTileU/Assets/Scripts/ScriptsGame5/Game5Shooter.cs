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
        
        public static float shotDelay = 1.0f / TimeManager.slowMotionMultiplier;
        private float lastShotFired;
        private float bulletOffset = 0.5f; // Where the bullet spawns

    // Script References

        Game5EnemyBullet game5EnemyBullet;


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
        GameObject bullet = Instantiate(bulletPrefab, game5Shooter.position + (transform.up * bulletOffset), game5Shooter.rotation); // Creates the instance of the prefab
    }

    protected override void EnemyMovement()
    {
        // Directional Movement
        distance = Vector2.Distance(transform.position, player.transform.position); // Calculates the distance between the enemy and the player
        Vector2 direction = player.transform.position - transform.position; // Calculates the direction it needs to face
        direction.Normalize();

        if(distance > 3)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); // Moves the enemy towards the player
        }

        if (distance < 2)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, -speed * Time.deltaTime); // Moves the enemy towards the player
        }




        // Rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
