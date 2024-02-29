using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float notFocusedSpeed;

    // SCRIPT REFERENCES

        

        
    // Start is called before the first frame update
    void Start()
    {
        notFocusedSpeed = 0.01f;

        // GAME VARIABLES
        
            // GAME 5
            /*
            game5Bullet = GameObject.FindGameObjectWithTag("Game5Player").GetComponent<Game5Bullet>();
            game5Enemy = GameObject.FindGameObjectWithTag("Game5Enemy").GetComponent<Game5Enemy>();
            game5PlayerController = GameObject.FindGameObjectWithTag("Game5Player").GetComponent<Game5PlayerController>();
            game5Shooter = GameObject.FindGameObjectWithTag("Game5Shooter").GetComponent<Game5Shooter>();
            */

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Focus4()
    {

    }

    public void Focus5()
    {
        // Bullet
        Game5Bullet.bulletSpeed = 10.0f;
        Game5Bullet.shotDelay = 0.3f;

        // Enemy
        Game5Enemy.speed = 3.0f;

        // Player
        Game5PlayerController.speed = 5.0f;
        Game5PlayerController.rotationSpeed = 4000.0f;

        // Shooter
        Game5Shooter.bulletSpeed = 10.0f;
        Game5Shooter.shotDelay = 1.0f;
    }
}
