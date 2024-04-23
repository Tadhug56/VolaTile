using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6EnemyHealth : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private float hitPoints = 2;
    [SerializeField] private int currencyWorth = 50;

    private bool isDestroyed = false;

    public void TakeDamage(float dmg)
    {
        hitPoints -= dmg;

        if(hitPoints <= 0 && !isDestroyed)
        {
            Game6Manager.main.IncreaseCurrency(currencyWorth); // Add money for defeating an enemy

            Game6Spawner.onEnemyDestroy.Invoke();
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
