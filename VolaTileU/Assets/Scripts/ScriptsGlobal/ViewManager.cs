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
    public static int focus;

    // Script References
    private TimeManager timeManager;
    private DefaultSpeeds speedManager;

    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        speedManager = GameObject.FindGameObjectWithTag("SpeedManager").GetComponent<DefaultSpeeds>();

        focus = 5;

        Focus();
    }

    void Update()
    {
        MoveFocus();
    }
 
    // CONTROLS CAMERA TRANSITIONS

    public void CameraTransition() // Will take in game parameters
    {
        camera5.rect = new Rect(.5f, 0f, newWidth, 1f);
        camera4.rect = new Rect(0f, 0f, newWidth, 1f);
        camera5.enabled = true;
        camera4.enabled = true;
    }

    public void MoveFocus()
    {
        if(Input.GetKeyDown("j"))
        {
            Debug.Log("J pressed");
            focus = 4;
            Focus();
        }

         if(Input.GetKeyDown("l"))
        {
            Debug.Log("L pressed");
            focus = 5;
            Focus();
        }
    }

    public void Focus()
    {
        Debug.Log("Focus Called");
        switch(focus)
        {
            case 4:

                timeManager.Focus4();
                speedManager.DefaultGame5();

            break;

            case 5:

                timeManager.Focus5();
                speedManager.DefaultGame4();
                
            break;

                
        }
    }
}
