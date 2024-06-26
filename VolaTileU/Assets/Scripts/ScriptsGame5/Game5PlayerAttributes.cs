using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5PlayerAttributes : MonoBehaviour
{
    public float health = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Takes the damage parameter of the weapon the player and removes health from the enemy based on that number and destroys the enemy if its health is below or equal to zero (Called when a collision is detected)
    public void TakeDamage(float damage)
    {
        health -= damage; // Deals the damage

        // If enemy has no health left destroy the enemy
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Game6Manager.main.currency >= 50)
        {
            Game6Manager.main.currency -= 50;
        }

        else
        {
            Game6Manager.main.currency = 0;
        }
    }
}
