using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Game5Bullet : MonoBehaviour
{
    // Bullet movement variables

        // Prefab / Spawnpoint Variables
        public Transform bulletSpawnPoint;
        public GameObject bulletPrefab;

        // Firing related variables
        private float bulletSpeed = 10.0f;
        private float shotDelay = 0.3f;
        private float lastShotFired;
        private bool fireContinously;

    // Update is called once per frame
    void FixedUpdate()
    {
        // If input is detected
        if(fireContinously)
        {
            float timeSinceLastFired = Time.time - lastShotFired; // Calculates the time since the last bullet was fired

            // If the delay is over
            if(timeSinceLastFired >= shotDelay)
            {
                FireBullet();

                lastShotFired = Time.time;
            }
        }
    }

    // Checks for input (SET TO SPACEBAR IN THE INPUT FILE)
    void OnFire(InputValue inputValue)
    {
        fireContinously = inputValue.isPressed;
    }

    // Creates the bullets
    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // Creates the instance of the prefab
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>(); // Gets the rigidbody of the newly created bullet

        bulletRb.velocity = transform.up * bulletSpeed; // Sets the velocity (Fires in the direction the spawn point is facing)
    }
}
