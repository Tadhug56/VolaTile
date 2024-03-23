using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4LaserCollision : MonoBehaviour
{
    public float laserLife = 1.0f;
    public float timeAlive;

    void Awake()
    {
        timeAlive = 0;
    }

    void Update()
    {
        DynamicLife();
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

    private void DynamicLife()
    {
        if(ViewManager.focus == 4)
        {
            timeAlive += Time.deltaTime;
        }

        else
        {
            timeAlive += (Time.deltaTime * TimeManager.slowMotionMultiplier);
        }

        if(timeAlive >= laserLife)
        {
            Destroy(gameObject);
        }
    }

}
