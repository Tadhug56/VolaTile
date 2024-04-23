using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6UpgradeManager : MonoBehaviour
{
    public Game6Turret game6Turret; // Reference to the turret script attached to the turret prefab

    public void UpgradeDamage()
    {
        game6Turret.UpgradeDamage(); // Call a method in TurretScript to upgrade damage
    }

    public void UpgradeRange()
    {
        game6Turret.UpgradeTargetingRange(); // Call a method in TurretScript to upgrade range
    }

    public void UpgradeFireRate()
    {
        game6Turret.UpgradeBps(); 
    }
}
