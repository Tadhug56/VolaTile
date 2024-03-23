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
        Game4SpawnManager.spawnDelay = 1.0f / TimeManager.slowMotionMultiplier;

        // Player
        Game4PlayerMovement.speed = 5.0f * TimeManager.slowMotionMultiplier;
        Game4PlayerMovement.rotationSpeed = 4000.0f * TimeManager.slowMotionMultiplier;

        // Laser
        //Game4LaserCollision.laserLife = 1.0f / TimeManager.slowMotionMultiplier;
    }

    public void DefaultGame5()
    {
        // Bullet
        Game5BulletCollision.bulletSpeed = 10.0f * TimeManager.slowMotionMultiplier;
        Game5Bullet.shotDelay = 0.3f / TimeManager.slowMotionMultiplier;
        Game5BulletCollision.bulletLife = 3.0f / TimeManager.slowMotionMultiplier;

        // Enemy
        Game5Enemy.speed = 3.0f * TimeManager.slowMotionMultiplier;
        Game5EnemyBulletCollision.bulletLife = 3.0f / TimeManager.slowMotionMultiplier;

        // Player
        Game5PlayerController.speed = 5.0f * TimeManager.slowMotionMultiplier;
        Game5PlayerController.rotationSpeed = 4000.0f * TimeManager.slowMotionMultiplier;

        // Shooter
        Game5EnemyBullet.enemyBulletSpeed = 10.0f * TimeManager.slowMotionMultiplier;
        Game5Shooter.shotDelay = 1.0f / TimeManager.slowMotionMultiplier;
    }
}
