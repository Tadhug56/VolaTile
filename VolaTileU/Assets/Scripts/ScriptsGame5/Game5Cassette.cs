using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5Cassette : MonoBehaviour
{
    private GameObject cassette;
    private Game5CameraController camera5;
    private GameObject player5;
    public ViewManager viewManager;

    // Start is called before the first frame update
    void Start()
    {
        camera5 = GameObject.FindGameObjectWithTag("Camera5").GetComponent<Game5CameraController>();
        viewManager = GameObject.FindGameObjectWithTag("ViewManager").GetComponent<ViewManager>();
        //player5 = GameObject.FindWithTag("Player");  // Assigns the enemies target to the player as it has the player tag

        if (viewManager == null)
        {
            Debug.LogError("ViewManager is not assigned to Game5Cassette.");
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("TOuching");
        }

        else if(other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        else
        {
            Debug.Log("NOT WORKING");
        }

        viewManager.CameraTransition();
    }
}
