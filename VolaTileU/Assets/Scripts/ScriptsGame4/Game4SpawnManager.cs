using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4SpawnManager : MonoBehaviour
{
    // Laser Variables
    public GameObject laserPrefab;
    
    
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
        public static float spawnDelay = 1.0f * TimeManager.slowMotionMultiplier;

        public static float dodgeTimer;
        public static float dodgeDelay = 0.5f * TimeManager.slowMotionMultiplier; 

    // Player Variables
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        // Initial Variable Assignments
        spawnTimer = spawnDelay;
        dodgeTimer = dodgeDelay;

        // Start the spawning logic
        StartCoroutine(SpawnRoutine());
    }


    // Handles spawning and the delays between spawn and dodge timers
    private IEnumerator SpawnRoutine()
    {
        // Continue spawning // TODO make conditional based on if the game is in view or not.
        while(true)
        {
            CalculateSpawnRange();
            yield return new WaitForSeconds(dodgeDelay);

            SpawnLasers();
            yield return new WaitForSeconds(spawnDelay);
        }
    }


    private void SpawnLasers()
    {       
        Instantiate(laserPrefab, spawnPositions[circlePosition], rotation);
    }


   // Creates a list of spawn positions around in a circle radius around the player that enemies can spawn from
    private void CalculateSpawnRange()
    {
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
