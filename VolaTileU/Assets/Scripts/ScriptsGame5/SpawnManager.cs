using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    // Spawn Manager Variables
    
        // Spawner Variables

        public List<Enemy> enemies = new List<Enemy>();
        public List<GameObject> enemiesToSpawn = new List<GameObject>();
        public Transform spawnLocation;
        private float spawnInterval;
        private float spawnTimer;

        // Wave Variables

        public int currentWave;
        public int waveValue;
        public int waveDuration;
        private float waveTimer;

        // Enemy Varaibles
        

    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
    }


    // Updates based on the physics frames
    void FixedUpdate()
    {
        if(spawnTimer <= 0)
        {
            if(enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnLocation.position, Quaternion.identity);
                enemiesToSpawn.RemoveAt(0);
                spawnTimer = spawnInterval;
            }

            else
            {
                waveTimer = 0;
            }
        }

        else
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }
    }


    // CREATED METHODS

    // Generates the wave of enemies based on wave value, spawn interval and wave timer
    public void GenerateWave()
    {
        waveValue = currentWave * 10; // Tokens to spend on enemies
        GenerateEnemies(); // Generates the enemies

        // Overhead wave values
        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }


    // Creates a list of enemies to be generated based on an enemies random id and their cost
    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>(); // Creates a new empty list of enemies to be spawned

        // While the wave still has tokens to spend on enemies
        while(waveValue > 0)
        {
            int randomEnemyId = Random.Range(0, enemies.Count); // Id of the enemy to be spawned
            int randomEnemyCost = enemies[randomEnemyId].cost; // Cost of the enemy to be spawned (TO CHANGE - Will be based on cost of a type of enemy)

            // If the cost of the latest enemy is less than the remaining tokens of the wave, add a new enemy to be spawned to the list
            if(waveValue - randomEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randomEnemyId].enemeyPrefab);
                waveValue -= randomEnemyCost;
            }

            // If no tokens remaining then end the loop
            else if(waveValue <= 0)
            {
                break;
            }
        }

        enemiesToSpawn.Clear(); // Clears the list of enemies to spawn
        enemiesToSpawn = generatedEnemies; // Sets the new list of enemies to spawn to the ones decided on this wave
    }


    // CLASS DEFINITIONS

    [System.Serializable]
    public class Enemy
    {
        public GameObject enemeyPrefab;
        public int cost;
    }
}
