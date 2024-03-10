using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    // Spawn Manager Variables
    
        // Spawner Variables

        public List<Enemy> enemies = new List<Enemy>();
        public List<GameObject> enemiesToSpawn = new List<GameObject>();
        public List<Vector3> spawnPositions;
        private Vector3 spawnPosition;
        private float spawnInterval;
        private float spawnTimer;
        private float radius = 8.0f;
        private float numberOfSpawnLocations = 12.0f;
        

        // Wave Variables

        public int currentWave;
        public int waveValue;
        public int waveDuration;
        private float waveTimer;

        // Enemy Variables

        // Player Variables
        
        public GameObject player;

        // Script References

        public ViewManager viewManager;

    // Start is called before the first frame update
    void Start()
    {
        GenerateWave();
        viewManager.Focus();
    }


    // Updates based on the physics frames
    void FixedUpdate()
    {
        CalculateSpawnRange();
        SpawnEnemies();
    }


    public void SpawnEnemies()
    {
        if(spawnTimer <= 0)
        {
            int circlePosition = Random.Range(0, spawnPositions.Count);
            if(enemiesToSpawn.Count > 0)
            {
                Instantiate(enemiesToSpawn[0], spawnPositions[circlePosition], Quaternion.identity);
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

    // Creates a list of spawn positions around in a circle radius around the player that enemies can spawn from
    private void CalculateSpawnRange()
    {
        float angleStep = 360f / numberOfSpawnLocations;;
        
        spawnPositions = new List<Vector3>(); // List to store calculated spawn positions

        for(int i = 0; i < numberOfSpawnLocations; i++)
        {
            float angle = angleStep * i;
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;
            Vector3 spawnPosition = player.transform.position + new Vector3(x, y, 0);
            spawnPositions.Add(spawnPosition);
        }
    }
    
    // CLASS DEFINITIONS

    [System.Serializable]
    public class Enemy
    {
        public GameObject enemeyPrefab;
        public int cost;
    }
}
