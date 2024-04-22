using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Game6TurretIce : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LayerMask enemyMask;

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 2.0f;
    [SerializeField] private float attackSpeed = 0.25f;
    [SerializeField] private float freezeValue = 0.5f;
    [SerializeField] private float freezeTime = 1.0f;

    private float timeUntilFire;

    private void Update()
    {
        timeUntilFire += Time.deltaTime;

        if(timeUntilFire >= 1.0f / attackSpeed)
        {
            FreezeEnemies();
            timeUntilFire = 0;
        }
    }

    private void FreezeEnemies()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0.0f, enemyMask);

        if(hits.Length > 0)
        {
            for(int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];

                Game6EnemyMovement em = hit.transform.GetComponent<Game6EnemyMovement>();
                em.UpdateSpeed(freezeValue);
            }
        }
    }

    private IEnumerator ResetEnemySpeed(Game6EnemyMovement em)
    {
        yield return new WaitForSeconds(freezeTime);
        em.ResetSpeed();
    }

     private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
