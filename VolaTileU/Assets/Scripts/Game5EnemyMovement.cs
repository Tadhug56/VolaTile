using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5EnemyMovement : MonoBehaviour
{
    // Enemey Movement Variables

        // Playe related variables
        public GameObject player;

        // Enemey related variables
        private float speed = 3.0f;
        private float distance;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");  // Assigns the enemies target to the player as it has the player tag
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    // Moves the enemy towards the player
    void EnemmyMovement()
    {
        distance = Vector2.Distance(transform.position, player.transform.position); // Calculates the distance between the enemy and the player
        Vector2 direction = player.transform.position - transform.position; // Calculates the direction it needs to face

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); // Moves the enmey towards the player
    }
}
