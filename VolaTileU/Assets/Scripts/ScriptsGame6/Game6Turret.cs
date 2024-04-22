using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Game6Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 3.0f;
    [SerializeField] private float rotationSpeed = 200.0f;
    [SerializeField] private float bps = 1.0f; // Bullets per second

    private Transform target;

    private float timeUntilFire;

    private void Update()
    {
        if(target == null)
        {
            FindTarget();
            return;
        }

        RotateTowardsTarget();

        if(CheckTargetIsInRange() == false)
        {
            target = null;
        }

        else
        {
            timeUntilFire += Time.deltaTime;

            if(timeUntilFire >= 1.0f / bps)
            {
                FireBullet();
                timeUntilFire = 0;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }

    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0.0f, enemyMask);

        if(hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    private void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90.0f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        transform.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Game6Bullet game6BulletScript = bullet.GetComponent<Game6Bullet>();
        game6BulletScript.SetTarget(target);
    }
}
