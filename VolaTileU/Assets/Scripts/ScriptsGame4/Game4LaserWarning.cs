using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4LaserWarning : MonoBehaviour
{

    private float timeAlive;
    private float laserLife = 1.0f;

    private float timeMultiplyer = 1;

    private void Update()
    {
        DynamicLife();
    }

    void OnEnable()
    {
        ViewManager.OnFocusChangeLaserWarning.AddListener(UpdateFocus); // Subscribe to the focus change event
    }

    void OnDisable()
    {
        ViewManager.OnFocusChangeLaserWarning.RemoveListener(UpdateFocus); // Unsubscribe from the focus change event
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
