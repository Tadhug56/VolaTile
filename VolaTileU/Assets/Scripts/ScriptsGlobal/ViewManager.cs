using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ViewManager : MonoBehaviour
{
    // Cameras
    public Camera camera5;
    public Camera camera4;
    public Camera camera6;

    // ViewManager Variables
    private float newWidth = 0.33f;
    public static int focus;
    private float changeFocusDelay = 1.0f;
    private float changeFocusTime;
    private int currentFocus;

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
        currentFocus = focus;

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
        camera5.rect = new Rect(0.333f, 0.333f, 0.333f, 0.333f);
        camera4.rect = new Rect(0f, 0.333f, 0.333f, 0.333f);
        camera6.rect = new Rect(0.667f, 0.333f, 0.333f, 0.333f);
        camera5.enabled = true;
        camera4.enabled = true;
        camera6.enabled = true;
    }

    public void MoveFocus()
    {
        if(changeFocusTime > changeFocusDelay)
        {
            if(Input.GetKeyDown("j")) // Farthest game made so far
            {
                if(focus > 4 )
                {
                    focus--;

                    Focus();
                    OnFocusChange.Invoke(focus);
                    changeFocusTime = 0;
                }
            }

            if(Input.GetKeyDown("l"))
            {   
                if(focus < 6)
                {
                    focus++;
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
                speedManager.DefaultGame6();
                
            break;

            case 6:

                timeManager.Focus6();
                speedManager.DefaultGame5();

                break;
        }
    }

    private void FocusChangeTiming()
    {
        changeFocusTime += Time.deltaTime;
    }
}
