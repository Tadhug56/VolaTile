using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Game5PlayerController : MonoBehaviour
{
    // Player Controller Variables

        // Movement Variables

            //Directional Variables
            public float speed = 5.0f;
            private float smoothMovementInputTime = 0.1f;
            private Vector2 moveInput;
            private Vector2 smoothMovementInput;
            private Vector2 smoothMovementInputVelocity; 

            // Rotation Variables
            private float rotationSpeed = 4000.0f;

        // Rigidbody Variables

        private Rigidbody2D playerRb;

    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }


    // Updates based on the physics frames
    void FixedUpdate()
    {
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
        moveInput = inputValue.Get<Vector2>();
    }
}
