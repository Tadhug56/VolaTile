using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4SpawnManager : MonoBehaviour
{
    // Laser Variables
    public GameObject laserPrefab;
    public GameObject laserWarningPrefab;
    public static Coroutine spawning;
    
    
    // Spawner Variables

        // Circle radius
        private List<Vector3> spawnPositions;
        private float radius = 8.0f;
        private float numberOfSpawnLocations = 12;

        // Instantiate
        private int circlePosition;
        Vector3 direction;
        Quaternion rotation;

        // Timers
        public static float spawnTimer;
        public static float spawnDelay = 2.0f / TimeManager.slowMotionMultiplier;

        public static float dodgeTimer;
        public static float dodgeDelay = 0.5f / TimeManager.slowMotionMultiplier; 

    // Player Variables
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        // Initial Variable Assignments
        spawnTimer = spawnDelay;
        dodgeTimer = dodgeDelay;

        // Start the spawning logic
        RestartSpawn();
    }

    public void RestartSpawn()
    {
        StartCoroutine(SpawnRoutine());
    }

    public void StopSpawning()
    {
        StopCoroutine(SpawnRoutine());
    }

    // Handles spawning and the delays between spawn and dodge timers
    private IEnumerator SpawnRoutine()
    {
        // Continue spawning // TODO make conditional based on if the game is in view or not.
        while(player != null)
        {
            float startTime = Time.time;
            
            // Spawn delay
            while(Time.time < startTime + spawnDelay)
            {
                yield return null;
            }

            CalculateSpawnRange(); // Calculate range around the player
            SpawnWarning(); // Spawn the warning

            startTime = Time.time;

            // Dodge delay
            while(Time.time < startTime + dodgeDelay)
            {
                yield return null;
            }
            
            SpawnLasers(); // Spawn the actual laser
        }
    }

    // Spawns lasers
    private void SpawnLasers()
    {       
        Instantiate(laserPrefab, spawnPositions[circlePosition], rotation);
    }

    // Spawns warning shot
    private void SpawnWarning()
    {
        Instantiate(laserWarningPrefab, spawnPositions[circlePosition], rotation);
    }


   // Creates a list of spawn positions around in a circle radius around the player that enemies can spawn from
    private void CalculateSpawnRange()
    {
        // If player is alive
        if(player == null)
        {
            return;
        }

        float angleStep = 360.0f / numberOfSpawnLocations; // Number of possible locations in the circle to spawn from
        
        spawnPositions = new List<Vector3>(); // List to store calculated spawn positions

        // For each possible location calculate where in the circle it should spawn
        for(int i = 0; i < numberOfSpawnLocations; i++)
        {
            // Circle math
            float angle = angleStep * i;
            float x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            float y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            // Add the vector3 to the list
            Vector3 spawnPosition = player.transform.position + new Vector3(x, y, 0); 
            spawnPositions.Add(spawnPosition);
            
            circlePosition = Random.Range(0, spawnPositions.Count); // Pick the possible location

            // Rotate and point towards the player
            direction = spawnPositions[circlePosition] - player.transform.position;
            rotation = Quaternion.LookRotation(Vector3.forward, direction);
        }    
    }
    
}
