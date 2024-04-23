using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class Game6Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint;
    [SerializeField] private LayerMask enemyMask;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;

    private float targetingRange = 3.0f;
    private float rotationSpeed = 500.0f;
    private float bps = 1.0f; // Bullets per second
    private float bulletDamage = 1.0f;

    // Upgrade Costs
    private int bpsUpgradeCost = 100;
    private int damageUpgradeCost = 200;
    private int targetingRangeUpgradeCost = 150;

    // Upgrade Levels
    private int bpsLevel = 1;
    private int targetingRangeLevel = 1;
    private int damageLevel = 1;
    private int level = 1;

    private Transform target;

    private float bpsBase;
    private float targetingRangeBase;
    private float bulletDamageBase;

    private float timeUntilFire;

    private void Start()
    {
        bps = 1.0f;
        targetingRange = 3.0f;
        bulletDamage = 1;

        bpsBase = bps;
        targetingRangeBase = targetingRange;
        bulletDamageBase = bulletDamage;
    }

    private void Update()
    {
        timeUntilFire += Time.deltaTime;

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
            if(timeUntilFire >= 1.0f / bps)
            {
                FireBullet();
                timeUntilFire = 0;
            }
        }
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

    // Fires a bullet
    private void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Game6Bullet game6BulletScript = bullet.GetComponent<Game6Bullet>();

        game6BulletScript.SetTarget(target);

        game6BulletScript.bulletDamage = bulletDamage;
    }


    // UPGRADE RELATED METHODS

    // Bps

    public void UpgradeBps()
    {
        if(!CanAfford(bpsUpgradeCost))
        {
            Debug.Log("You can't afford this upgrade");
            return;
        }

        Game6Manager.main.SpendCurrency(CalculateCost(bpsUpgradeCost));

        bps = CalculateBps();

        bpsLevel++;
        level++;

        Debug.Log("Bps " + bps);
    }

    private float CalculateBps()
    {
        Debug.Log("math " + Mathf.Pow(bpsLevel, 0.6f));
        Debug.Log("base " + bpsBase);
        return (bps + 10000.0f);
        //return (bpsBase * Mathf.Pow(bpsLevel, 0.6f));
    }

    // Range

    public void UpgradeTargetingRange()
    {
        if(!CanAfford(targetingRangeUpgradeCost))
        {
            Debug.Log("You can't afford this upgrade");
            return;
        }

        Game6Manager.main.SpendCurrency(CalculateCost(targetingRangeUpgradeCost));

        targetingRange = CalculateRange();

        targetingRangeLevel++;
        level++;
    }

    private float CalculateRange()
    {
        return targetingRangeBase * Mathf.Pow(targetingRangeLevel, 0.4f);
    }

    // Damage

    public void UpgradeDamage()
    {
        if(!CanAfford(damageUpgradeCost))
        {
            Debug.Log("You can't afford this upgrade");
            return;
        }

        Game6Manager.main.SpendCurrency(CalculateCost(damageUpgradeCost));

        bulletDamage = CalculateDamage();

        damageLevel++;
        level++;
    }

    private float CalculateDamage()
    {
        return bulletDamage++;
    }

    // Cost Related Methods

    private int CalculateCost(int upgradeCost)
    {
        return Mathf.RoundToInt(upgradeCost * Mathf.Pow(level, 0.8f));
    }

    private bool CanAfford(int cost)
    {
        if(CalculateCost(cost) > Game6Manager.main.currency)
        {
            return false;
        }

        else
        {
            return true;
        }
    }

    // EXTRA EDITOR RELATED METHODS

    // Draws the range in the editor when selected
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
