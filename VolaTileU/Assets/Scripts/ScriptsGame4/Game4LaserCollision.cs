using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Game4LaserCollision : MonoBehaviour
{
    // Laser Life Variables
    public float laserLife = 1.0f;
    public float timeAlive;
    public float timeMultiplyer;

    // Currency Related Variables
    private float bonusTime;
    private bool alive;

    void Awake()
    {
        timeAlive = 0; // Set time alive to 0
        timeMultiplyer = 1; // Default timemultiplyer
        alive = true; // Default set to true
    }

    void Update()
    {
        DynamicLife(); // Life tracking taking slow down into account
        AliveBonus(); // Tracks currency rewards for being alive
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject; // Sets player to the collision object
        Game4PlayerMovement game4PlayerMovement = player.GetComponent<Game4PlayerMovement>(); // Gets movement script
        PlayerInput playerInput = player.GetComponent<PlayerInput>(); // Gets input manager

        
        // If the laser collides with an player delete the bullet and deal damage
        if(player)
        {
            game4PlayerMovement.playerHealth -= 1; // Reduces health by 1
            Destroy(gameObject); // Destroys the laser

            // If health reaches 0
            if(game4PlayerMovement.playerHealth == 0)
            {
                Destroy(player); // Destroy player object
                playerInput.enabled = false; // Disable input manager
                alive = false; // Set alive to false
            }
        }
    }

    // Updates based on if the game is in focus
    private void UpdateFocus(int focus)
    {
        // If in focus
        if(focus == 4)
        {
            timeMultiplyer = 1.0f;
        }

        // If not in focus
        else
        {
            timeMultiplyer = TimeManager.slowMotionMultiplier;
        }
    }

    // Logic for life of laser based on slow down factor
    private void DynamicLife()
    {
        timeAlive += Time.deltaTime * timeMultiplyer;

        if (timeAlive >= laserLife)
        {
            Destroy(gameObject);
        }
    }

    // Handles logic for bonus Currency for being alive
    private void AliveBonus()
    {
        // If not alive
        if(alive == false)
        {
            return;
        }

        bonusTime += Time.deltaTime;

        // Every second give currency
        if(bonusTime >= 1.0f)
        {
            Game6Manager.main.currency += 5;
            bonusTime = 0;
        }
    }

    void OnEnable()
    {
        ViewManager.OnFocusChange.AddListener(UpdateFocus); // Subscribe to the focus change event
    }

    void OnDisable()
    {
        ViewManager.OnFocusChange.RemoveListener(UpdateFocus); // Unsubscribe from the focus change event
    }
}
