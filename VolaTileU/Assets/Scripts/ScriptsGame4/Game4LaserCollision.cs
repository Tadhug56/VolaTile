using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4LaserCollision : MonoBehaviour
{
    public static float laserLife = 1.0f * TimeManager.slowMotionMultiplier;

    void Awake()
    {
        Destroy(gameObject, laserLife); // Destroys the bullet after its time is up
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
         var player = collision.GetComponent<Game4PlayerMovement>();
        
        // If the laser collides with an player delete the bullet and deal damage
        if(player)
        {
            Debug.Log("Detected");
            Destroy(gameObject); // Destroys the laser
            Destroy(player);
        }
    
    }
}
