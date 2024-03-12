using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5Cassette : MonoBehaviour
{
    // Object Variables
    private GameObject cassette;
    private Game5CameraController camera5;
    private GameObject player5;

    // Script References
    private ViewManager viewManager;
    private TimeManager timeManager;


    // Start is called before the first frame update
    void Start()
    {
        // Assignments

            // Camera assignments
            camera5 = GameObject.FindGameObjectWithTag("Camera5").GetComponent<Game5CameraController>();

            // ViewManager
            viewManager = GameObject.FindGameObjectWithTag("ViewManager").GetComponent<ViewManager>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Game5Player"))
        {
            ViewManager.focus = 4;
            viewManager.Focus();
            viewManager.CameraTransition();

            Destroy(gameObject);
        }
    }   
}
