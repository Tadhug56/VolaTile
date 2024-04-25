using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpeeds : MonoBehaviour
{
    // KEY : * FOR VALUES TO GO DOWN : / FOR VALUES TO GO UP

    public void DefaultGame4()
    {
        // Spawners
        Game4SpawnManager.dodgeDelay = 0.5f / TimeManager.slowMotionMultiplier;
        Game4SpawnManager.spawnDelay = 2.0f / TimeManager.slowMotionMultiplier;

        // Player
        Game4PlayerMovement.speed = 5.0f * TimeManager.slowMotionMultiplier;
        Game4PlayerMovement.rotationSpeed = 4000.0f * TimeManager.slowMotionMultiplier;    
    }

    public void DefaultGame5()
    {
        // Bullet
        Game5BulletCollision.bulletSpeed = 10.0f * TimeManager.slowMotionMultiplier;
        Game5Bullet.shotDelay = 0.3f / TimeManager.slowMotionMultiplier;
        Game5BulletCollision.bulletLife = 3.0f / TimeManager.slowMotionMultiplier;

        // Enemy
        Game5Enemy.speed = 3.0f * TimeManager.slowMotionMultiplier;

        // Player
        Game5PlayerController.speed = 5.0f * TimeManager.slowMotionMultiplier;
        Game5PlayerController.rotationSpeed = 4000.0f * TimeManager.slowMotionMultiplier;

        // Shooter
        Game5EnemyBullet.enemyBulletSpeed = 10.0f * TimeManager.slowMotionMultiplier;
        Game5Shooter.shotDelay = 1.0f / TimeManager.slowMotionMultiplier;
    }

    public void DefaultGame6()
    {
        // Ice Turret
        Game6TurretIce.attackSpeed = 0.25f * TimeManager.slowMotionMultiplier;
        Game6TurretIce.freezeTime = 1.0f / TimeManager.slowMotionMultiplier;

        // Basic Turret
        Game6Turret.bps = 1 * TimeManager.slowMotionMultiplier;
        Game6Turret.rotationSpeed = 500.0f * TimeManager.slowMotionMultiplier;
        Game6Turret.fireDelay = 1.0f / TimeManager.slowMotionMultiplier;

        // Spawner
        Game6Spawner.timeBetweenWaves = 0.5f / TimeManager.slowMotionMultiplier;
        Game6Spawner.spawnTimer = (Game6Spawner.spawnDelay / Game6Spawner.eps) / TimeManager.slowMotionMultiplier;

        // Basic Enemey BUG fix resetting movement on focus change if frozen by ice turret
        Game6EnemyMovement.moveSpeed = 2.0f * TimeManager.slowMotionMultiplier;
        Game6EnemyMovement.baseSpeed = Game6EnemyMovement.moveSpeed;
        
        // Bullets
        Game6Bullet.bulletSpeed = 5.0f * TimeManager.slowMotionMultiplier;
    }
}
