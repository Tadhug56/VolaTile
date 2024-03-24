using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game4LaserCollision : MonoBehaviour
{
    public float laserLife = 1.0f;
    public float timeAlive;
    public float timeMultiplyer;

    void Awake()
    {
        timeAlive = 0;
        timeMultiplyer = 1;
    }

    void Update()
    {
        DynamicLife();
    }

    void OnEnable()
    {
        ViewManager.OnFocusChange.AddListener(UpdateFocus); // Subscribe to the focus change event
    }

    void OnDisable()
    {
        ViewManager.OnFocusChange.RemoveListener(UpdateFocus); // Unsubscribe from the focus change event
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

    private void UpdateFocus(int focus)
    {
        if(focus == 4)
        {
            timeMultiplyer = 1.0f;
        }

        else
        {
            timeMultiplyer = TimeManager.slowMotionMultiplier;
        }
    }

    private void DynamicLife()
    {
        timeAlive += Time.deltaTime * timeMultiplyer;

        if (timeAlive >= laserLife)
        {
            Destroy(gameObject);
        }
    }
}
