using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Game4LaserCollision : MonoBehaviour
{
    public float laserLife = 1.0f;
    public float timeAlive;
    public float timeMultiplyer;

    private float bonusTime;
    private bool alive;

    void Awake()
    {
        timeAlive = 0;
        timeMultiplyer = 1;
        alive = true;
    }

    void Update()
    {
        DynamicLife();
        AliveBonus();
    }

    void OnEnable()
    {
        ViewManager.OnFocusChange.AddListener(UpdateFocus); // Subscribe to the focus change event
    }

    void OnDisable()
    {
        ViewManager.OnFocusChange.RemoveListener(UpdateFocus); // Unsubscribe from the focus change event
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        Game4PlayerMovement game4PlayerMovement = player.GetComponent<Game4PlayerMovement>();
        PlayerInput playerInput = player.GetComponent<PlayerInput>();

        
        // If the laser collides with an player delete the bullet and deal damage
        if(player)
        {
            game4PlayerMovement.playerHealth -= 1;
            Debug.Log("Detected");
            Destroy(gameObject); // Destroys the laser

            if(game4PlayerMovement.playerHealth == 0)
            {
                Destroy(player);
                playerInput.enabled = false;
                alive = false;
            }
        }
    }

    private void UpdateFocus(int focus)
    {
        if(focus == 4)
        {
            timeMultiplyer = 1.0f;
        }

        else
        {
            timeMultiplyer = TimeManager.slowMotionMultiplier;
        }
    }

    private void DynamicLife()
    {
        timeAlive += Time.deltaTime * timeMultiplyer;

        if (timeAlive >= laserLife)
        {
            Destroy(gameObject);
        }
    }

    private void AliveBonus()
    {
        if(alive == false)
        {
            return;
        }

        bonusTime += Time.deltaTime;

        if(bonusTime >= 1.0f)
        {
            Debug.Log("bonus time");
            Game6Manager.main.currency += 5;
            bonusTime = 0;
        }
    }
}
