using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game6BuildManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] buildingPrefabs;
    public static Game6BuildManager main;

    private int selectedTower = 0;

    private void Awake()
    {
        main = this;
    }

    public GameObject GetSelectedTower()
    {
        return buildingPrefabs[selectedTower];
    }
}
