using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Game4PlayerMovement : MonoBehaviour
{
    // Player Controller Variables

        // Movement Variables

            //Directional Variables
            public static float speed = 5.0f * TimeManager.slowMotionMultiplier;
            private float smoothMovementInputTime = 0.1f;
            private Vector2 moveInput;
            private Vector2 smoothMovementInput;
            private Vector2 smoothMovementInputVelocity;

            // Rotation Variables
            public static float rotationSpeed = 4000.0f * TimeManager.slowMotionMultiplier;

        // Rigidbody Variables

        private Rigidbody2D playerRb;

    // Health Variables

        public int playerHealth;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerHealth = 3;
    }


    // Updates based on the physics frames
    void FixedUpdate()
    {
        if(gameObject == null)
        {
            return;
        }

        Movement();
        RotationDirection();
    }


    // Directional movement for the player
    void Movement()
    {
        // Smooths out the movement so that it's not instantanious
        smoothMovementInput = Vector2.SmoothDamp(smoothMovementInput, moveInput, ref smoothMovementInputVelocity, smoothMovementInputTime);
        playerRb.velocity = smoothMovementInput * speed; // Applies the movement
    }


    //  Rotational movement for the player
    void RotationDirection()
    {
        // If movement is detected
        if(moveInput != Vector2.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, smoothMovementInput); // Takes the direction of movement
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // Does the rotation calculations
            playerRb.MoveRotation(rotation); // Applies the rotation
        }
    }


    // Check for movement inputs
    private void OnMove(InputValue inputValue)
    {
        if(gameObject == null)
        {
            return;
        }
        moveInput = inputValue.Get<Vector2>();
    }

}
