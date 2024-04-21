using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6Manager : MonoBehaviour
{
    // Reference
    public static Game6Manager main;

    // Path related Variables
    public Transform[] path;
    public Transform startPoint;
   
    private void Awake()
    {
        main = this;
    }
}
