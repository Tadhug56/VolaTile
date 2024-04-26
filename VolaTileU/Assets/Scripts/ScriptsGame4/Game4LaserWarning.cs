using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4LaserWarning : MonoBehaviour
{
    // Laser Related Variables
    private float timeAlive; // Time the laser has been alive for
    private float laserLife = 1.0f; // Time the laser should be alive for

    // TimeMultiplyer
    private float timeMultiplyer = 1;

    private void Update()
    {
        DynamicLife(); // Track time alive with slowdown in mind
    }

    // Update the value of timeMultiplyer based on if the game is in focus or not
    private void UpdateFocus(int focus)
    {
        // If in focus timescale is normal
        if(focus == 4)
        {
            timeMultiplyer = 1.0f;
        }

        // Otherwise set it to the slowMotionMultiplier
        else
        {
            timeMultiplyer = TimeManager.slowMotionMultiplier;
        }
    }

    // Track life of laser warning taking the slow down into consideration
    private void DynamicLife()
    {
        timeAlive += Time.deltaTime * timeMultiplyer; // Multiply it by the current timescale

        // If time to be alive runs out
        if (timeAlive >= laserLife)
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        ViewManager.OnFocusChangeLaserWarning.AddListener(UpdateFocus); // Subscribe to the focus change event
    }

    void OnDisable()
    {
        ViewManager.OnFocusChangeLaserWarning.RemoveListener(UpdateFocus); // Unsubscribe from the focus change event
    }
}
