using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6Plot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private Color hoverColor;

    private GameObject tower;
    private Color startColor;

    private void Start()
    {
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
        if(tower != null)
        {
            return;
        }

        Game6Tower towerToBuild = Game6BuildManager.main.GetSelectedTower();

        if(towerToBuild.cost > Game6Manager.main.currency)
        {
            Debug.Log("You can't afford this tower!");
            return;
        }

        Game6Manager.main.SpendCurrency(towerToBuild.cost);

        Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
    }
}
