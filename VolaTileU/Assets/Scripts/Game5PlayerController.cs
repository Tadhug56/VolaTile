using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    private Rigidbody2D playerRb;
    private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Forwards / Backwords movement
        moveInput.y = Input.GetAxisRaw("Vertical");

        // Horizontal movement
        moveInput.x = Input.GetAxisRaw("Horizontal");

        moveInput.Normalize();

        playerRb.velocity = moveInput * speed;
       
    }
}
