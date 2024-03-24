using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewManager : MonoBehaviour
{
    // Cameras
    public Camera camera5;
    public Camera camera4;

    // ViewManager Variables
    private float newWidth = 0.5f;
    public static int focus;
    private float changeFocusDelay = 1.0f;
    private float changeFocusTime;

    // Script References
    private TimeManager timeManager;
    private DefaultSpeeds speedManager;

    // Events
    public static UnityEvent<int> OnFocusChange = new UnityEvent<int>();

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
        FocusChangeTiming();
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
        if(changeFocusTime > changeFocusDelay)
        {
            Debug.Log("Focus changed");
            if(Input.GetKeyDown("j"))
            {
                if(focus != 4)
                {
                    focus = 4;
                    Focus();
                    OnFocusChange.Invoke(focus);
                    changeFocusTime = 0;
                }
            }

            if(Input.GetKeyDown("l"))
            {   
                if(focus != 5)
                {
                    focus = 5;
                    Focus();
                    OnFocusChange.Invoke(focus); 
                    changeFocusTime = 0;
                }
            }
        }
    }

    public void Focus()
    {
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

    private void FocusChangeTiming()
    {
        changeFocusTime += Time.deltaTime;
    }
}
