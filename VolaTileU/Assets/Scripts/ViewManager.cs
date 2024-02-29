using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewManager : MonoBehaviour
{
    public Camera camera5;
    public Camera camera4;


    private float newWidth = 0.5f;

    // CONTROLS CAMERA TRANSITIONS

    public void CameraTransition() // Will take in game parameters
    {
        camera5.rect = new Rect(.5f, 0f, newWidth, 1f);
        camera4.rect = new Rect(0f, 0f, newWidth, 1f);
        camera5.enabled = true;
        camera4.enabled = true;
    }
}
