using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4CameraController : MonoBehaviour
{
    // Camera Variables

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If player is still alive
        if(target == null)
        {
            return;
        }
        
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z); // Moves the camera with the player
    }
}
