using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static float slowMotionMultiplier;

    // SCRIPT REFERENCES
    private Game4SpawnManager game4SpawnManger;
        

        
    // Start is called before the first frame update
    void Start()
    {
        slowMotionMultiplier = 0.05f;
        game4SpawnManger = GameObject.FindGameObjectWithTag("Game4SpawnManager").GetComponent<Game4SpawnManager>();
    }

    public void Focus4()
    {
        // Spawners
        Game4SpawnManager.dodgeDelay = 0.5f;
        Game4SpawnManager.spawnDelay = 1.0f;

        // Player
        Game4PlayerMovement.speed = 5.0f;
        Game4PlayerMovement.rotationSpeed = 4000.0f;

        // Laser
    
    }

    public void Focus5()
    {
        // Bullet
        Game5BulletCollision.bulletSpeed = 10.0f;
        Game5Bullet.shotDelay = 0.3f;
        Game5BulletCollision.bulletLife = 3.0f;

        // Enemy
        Game5Enemy.speed = 3.0f;

        // Player
        Game5PlayerController.speed = 5.0f;
        Game5PlayerController.rotationSpeed = 4000.0f;

        // Shooter
        Game5Shooter.shotDelay = 1.0f;
        Game5EnemyBullet.enemyBulletSpeed = 10.0f;
    }
}
