using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] public static float bulletSpeed = 5.0f;
    [SerializeField] public float bulletDamage;

    public Transform target;

    private void FixedUpdate()
    {
        if(!target)
        {
            Destroy(gameObject);
            return;
        }

        Vector2 direction = (target.position - transform.position).normalized;

        rb.velocity = direction * bulletSpeed;
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<Game6EnemyHealth>().TakeDamage(bulletDamage);
        Destroy(gameObject);    
    }
}
