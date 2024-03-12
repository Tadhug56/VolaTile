using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game5Enemy : MonoBehaviour
{
    // Enemy Variables

        // Health related variables
        protected float health;
        protected float maxHealth = 5.0f;
    

    // Enemey Movement Variables

        // Playe related variables
        protected GameObject player;

        // Enemey related variables
        private Rigidbody2D enemy;
        public static float speed = 3.0f * TimeManager.slowMotionMultiplier;
        protected float distance;
    
    // Script References

        // Time management
        protected TimeManager timeManager;


    // Start is called before the first frame update
    void Start()
    {
        enemy = this.GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Game5Player");  // Assigns the enemies target to the player as it has the player tag
        health = maxHealth;

        // Time Manager

         timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }


    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        Attack();
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
    protected virtual void EnemyMovement()
    {
        // Directional Movement
        //distance = Vector2.Distance(transform.position, player.transform.position); // Calculates the distance between the enemy and the player
        Vector2 direction = player.transform.position - transform.position; // Calculates the direction it needs to face
        direction.Normalize();

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); // Moves the enemy towards the player

        // Rotation
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    protected virtual void Attack()
    {
        // DO NOTHING
    }
}
