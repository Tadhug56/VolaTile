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

    [Header("Attributes")]
    [SerializeField] private float targetingRange = 2.5f;
    [SerializeField] private float rotationSpeed = 500.0f;
    [SerializeField] private float bps = 1.0f; // Bullets per second
    [SerializeField] private float bulletDamage = 1.0f;

    // Upgrade Costs
    public int bpsUpgradeCost = 100;
    public int damageUpgradeCost = 200;
    public int targetingRangeUpgradeCost = 150;
    public int[] upgradeCosts;

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

        upgradeCosts = new int[3];

        UpdatePrice();
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

        Game6Manager.main.SpendCurrency(bpsUpgradeCost);

        bpsUpgradeCost = CalculateCost(bpsUpgradeCost); // Update the cost
        UpdatePrice();
        Game6UpgradeMenu.main.UpdateCosts(upgradeCosts);

        bps = CalculateBps();

        bpsLevel++;
        level++;

        
    }

    private float CalculateBps()
    {
        return bps + 1;
    }

    // Range

    public void UpgradeTargetingRange()
    {
        if(!CanAfford(targetingRangeUpgradeCost))
        {
            Debug.Log("You can't afford this upgrade");
            return;
        }

        Game6Manager.main.SpendCurrency(targetingRangeUpgradeCost); // Spend the cost

        targetingRangeUpgradeCost = CalculateCost(targetingRangeUpgradeCost); // Update the cost
        UpdatePrice();
        Game6UpgradeMenu.main.UpdateCosts(upgradeCosts);

        targetingRange = CalculateRange(); // Upgrade range

        targetingRangeLevel++; // Increase targetRange level
        level++; // Increase general level
    }

    private float CalculateRange()
    {
        return targetingRange + 0.5f;
    }

    // Damage

    public void UpgradeDamage()
    {
        if(!CanAfford(damageUpgradeCost))
        {
            Debug.Log("You can't afford this upgrade");
            return;
        }

        Game6Manager.main.SpendCurrency(damageUpgradeCost);

        damageUpgradeCost = CalculateCost(damageUpgradeCost); // Update the cost
        UpdatePrice();
        Game6UpgradeMenu.main.UpdateCosts(upgradeCosts);

        bulletDamage = CalculateDamage();

        damageLevel++;
        level++;
    }

    private float CalculateDamage()
    {
        return ++bulletDamage;
    }

    // Cost Related Methods

    private int CalculateCost(int upgradeCost)
    {
        return Mathf.RoundToInt(upgradeCost * 1.5f);
    }

    private bool CanAfford(int cost)
    {
        if(cost > Game6Manager.main.currency)
        {
            return false;
        }

        else
        {
            return true;
        }
    }

    private void UpdatePrice()
    {
        upgradeCosts[0] = bpsUpgradeCost;
        upgradeCosts[1] = targetingRangeUpgradeCost; 
        upgradeCosts[2] = damageUpgradeCost;
    }

    // EXTRA EDITOR RELATED METHODS

    // Draws the range in the editor when selected
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
}
