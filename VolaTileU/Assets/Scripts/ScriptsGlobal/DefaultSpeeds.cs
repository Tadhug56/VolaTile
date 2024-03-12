using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSpeeds : MonoBehaviour
{
   public void DefaultGame5()
    {
        // Bullet
        Game5Bullet.bulletSpeed = 10.0f * TimeManager.slowMotionMultiplier;
        Game5Bullet.shotDelay = 0.3f * TimeManager.slowMotionMultiplier;
        Game5BulletCollision.bulletLife = 3.0f * TimeManager.slowMotionMultiplier;

        // Enemy
        Game5Enemy.speed = 3.0f * TimeManager.slowMotionMultiplier;
        Game5EnemyBulletCollision.bulletLife = 3.0f * TimeManager.slowMotionMultiplier;

        // Player
        Game5PlayerController.speed = 5.0f * TimeManager.slowMotionMultiplier;
        Game5PlayerController.rotationSpeed = 4000.0f * TimeManager.slowMotionMultiplier;

        // Shooter
        Game5Shooter.bulletSpeed = 10.0f * TimeManager.slowMotionMultiplier;
        Game5Shooter.shotDelay = 1.0f * TimeManager.slowMotionMultiplier;
    }
}
