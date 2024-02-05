using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5Enemy : MonoBehaviour
{
    // Enemy Variables

        // Health related variables
        private float health;
        public float maxHealth = 5.0f;

    // Enemey Movement Variables

        // Playe related variables
        private GameObject player;

        // Enemey related variables
        private float speed = 3.0f;
        private float distance;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");  // Assigns the enemies target to the player as it has the player tag
        health = maxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
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

    // Moves the enemy towards the player
    void EnemyMovement()
    {
        distance = Vector2.Distance(transform.position, player.transform.position); // Calculates the distance between the enemy and the player
        Vector2 direction = player.transform.position - transform.position; // Calculates the direction it needs to face

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); // Moves the enmey towards the player
    }
}
