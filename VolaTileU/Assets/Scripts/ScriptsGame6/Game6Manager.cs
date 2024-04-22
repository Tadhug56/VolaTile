using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6Manager : MonoBehaviour
{
    // Reference
    public static Game6Manager main;

    // Path related Variables
    public Transform[] path;
    public Transform startPoint;

    public int currency;
   
    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        currency = 300;
    }

    public void IncreaseCurrency(int amount)
    {
        currency += amount;
    }

    public bool SpendCurrency(int amount)
    {
        if(amount <= currency)
        {
            // Buy item
            currency -= amount;
            return true;
        }

        else
        {
            Debug.Log("You do not have enough to purchase this item");
            return false;
        }
    }
}
