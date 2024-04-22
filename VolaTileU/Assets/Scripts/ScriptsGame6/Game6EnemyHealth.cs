using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6EnemyHealth : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;

    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg;

        if(hitPoints <= 0)
        {
            Game6Spawner.onEnemyDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}
