using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6BuildManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Game6Tower[] towers;
    public static Game6BuildManager main;

    private int selectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public Game6Tower GetSelectedTower()
    {
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower)
    {
        selectedTower = _selectedTower;
    }
}
