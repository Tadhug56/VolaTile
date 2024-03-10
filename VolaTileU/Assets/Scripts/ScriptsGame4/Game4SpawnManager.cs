using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game4SpawnManager : MonoBehaviour
{
    // Laser Variables
    public GameObject laserPrefab;
    
    
    // Spawner Variables
    private Transform spawnLocation;

    public Transform spawnerN;
    public Transform spawnerS;
    public Transform spawnerE;
    public Transform spawnerW;

    public static float spawnTimer;
    public static float spawnDelay = 1000f;

    // Player Variables
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        SpawnLasers();
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer <= 0)
        {
            SpawnLasers();
            spawnTimer = spawnDelay;
        }

        else
        {
            spawnTimer -= Time.fixedDeltaTime;
        }
    }

    private void SpawnLasers()
    {
        spawnLocation = WhichSpawner();
        Vector3 direction = player.transform.position-transform.position;
        spawnLocation.rotation = Quaternion.LookRotation(direction);
        Instantiate(laserPrefab, spawnLocation.position, spawnLocation.rotation);
    }

    private Transform WhichSpawner()
    {
        int spawner = Random.Range(1, 4);

        switch(spawner)
        {
            case 1:

                return spawnerN;

            case 2:

                return spawnerS;

            case 3:

                return spawnerW;

            case 4:

                return spawnerE;

            default:

                return spawnerN;
                
        }
    }
}
