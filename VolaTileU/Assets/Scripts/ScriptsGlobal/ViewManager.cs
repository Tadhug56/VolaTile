using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    // Cameras
    public Camera camera5;
    public Camera camera4;

    // ViewManager Variables
    private float newWidth = 0.5f;
    public int focus;

    // Script References
    private TimeManager timeManager;

    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();

        focus = 5;
    }

    void Update()
    {
        Focus();
    }
 
    // CONTROLS CAMERA TRANSITIONS

    public void CameraTransition() // Will take in game parameters
    {
        camera5.rect = new Rect(.5f, 0f, newWidth, 1f);
        camera4.rect = new Rect(0f, 0f, newWidth, 1f);
        camera5.enabled = true;
        camera4.enabled = true;
    }

    public void Focus()
    {
        switch(focus)
        {
            case 4:

                timeManager.Focus4();

            break;

            case 5:

                timeManager.Focus5();

            break;

                
        }
    }
}
