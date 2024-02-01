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

    public void GenerateWave()
    {
        waveValue = currentWave * 10;
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;
        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();

        while(waveValue > 0)
        {
            int randomEnemyId = Random.Range(0, enemies.Count);
            int randomEnemyCost = enemies[randomEnemyId].cost;

            if(waveValue - randomEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randomEnemyId].enemeyPrefab);
                waveValue -= randomEnemyCost;
            }

            else if(waveValue <= 0)
            {
                break;
            }
        }

        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }

    // CLASS DEFINITIONS

    [System.Serializable]
    public class Enemy
    {
        public GameObject enemeyPrefab;
        public int cost;
    }
}
