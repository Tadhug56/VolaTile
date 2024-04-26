using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;
    
    [Header("Attributes")]
    [SerializeField] public static float moveSpeed = 2.0f * TimeManager.slowMotionMultiplier;

    private Transform target;
    private int pathIndex = 0;

    public static float baseSpeed = moveSpeed;

    private void Start()
    {
        baseSpeed = moveSpeed;
        target = Game6Manager.main.path[pathIndex];
    }

    private void Update()
    {
        if(Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++;

            if(pathIndex == Game6Manager.main.path.Length)
            {
                Game6Spawner.onEnemyDestroy.Invoke();
                Destroy(gameObject);
                Game6Manager.main.currency -= 100;
                return;
            }

            else
            {
                target = Game6Manager.main.path[pathIndex];
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * moveSpeed;
    }

    public void UpdateSpeed(float newSpeed)
    {
        moveSpeed = newSpeed;
    }

    public void ResetSpeed()
    {
        moveSpeed = baseSpeed;
    }
}
