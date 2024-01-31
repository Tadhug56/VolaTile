using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5EnemyMovement : MonoBehaviour
{
    // VARIABLE INITILISATION / ASSIGNMENTS

    // Public
    public GameObject player;

    // Private
    private float speed = 3.0f;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        // Assigns the enemies target to the player
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
