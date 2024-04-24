using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;
    [SerializeField] public Game6Turret game6Turret;

    private Game6UpgradeMenu game6UpgradeMenu;
    public GameObject towerObj;
    private Color startColor;

    private void Start()
    {
        game6UpgradeMenu = GameObject.FindGameObjectWithTag("Game6UpgradeMenu").GetComponent<Game6UpgradeMenu>();
        startColor = sr.color;
    }

    private void OnMouseEnter()
    {
        sr.color = hoverColor;
    }

    private void OnMouseExit()
    {
        sr.color = startColor;
    }

    private void OnMouseDown()
    {
        if(towerObj != null)
        {
            if(game6UpgradeMenu.isUpgradeMenuOpen == false)
            {
                game6UpgradeMenu.ToggleMenu();
            }

            Game6UpgradeManager game6UpgradeManager = game6UpgradeMenu.GetComponent<Game6UpgradeManager>();
            game6UpgradeManager.game6Turret = game6Turret;
            Game6UpgradeMenu.main.UpdateCosts(game6Turret.upgradeCosts);

            return;
        }

        Game6Tower towerToBuild = Game6BuildManager.main.GetSelectedTower();

        if(towerToBuild.cost > Game6Manager.main.currency)
        {
            Debug.Log("You can't afford this tower!");
            return;
        }

        Game6Manager.main.SpendCurrency(towerToBuild.cost);

        towerObj = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
        game6Turret = towerObj.GetComponent<Game6Turret>();
    }
}
