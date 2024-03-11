using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4SpawnManager : MonoBehaviour
{
    // Laser Variables
    public GameObject laserPrefab;
    
    
    // Spawner Variables
    private List<Vector3> spawnPositions;
    private Transform spawnLocation;
    private float radius = 8.0f;
    private float numberOfSpawnLocations = 12;
    public static float spawnTimer;
    public static float spawnDelay = 25.0f;

    // Player Variables
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateSpawnRange();

        SpawnLasers();
    }


    private void SpawnLasers()
    {
        if(spawnTimer <= 0)
        {
            int circlePosition = Random.Range(0, spawnPositions.Count);

            Vector3 direction = spawnPositions[circlePosition] - player.transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

            Instantiate(laserPrefab, spawnPositions[circlePosition], rotation);

            spawnTimer = spawnDelay;
        }

        else
        {
            spawnTimer -= Time.fixedDeltaTime;
        }
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
    
}
