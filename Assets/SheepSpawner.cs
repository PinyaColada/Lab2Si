using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawner : MonoBehaviour
{
    public bool canSpawn = true; // 1

    public GameObject sheepPrefab; // 2

    public Transform firstSpawn;
    public Transform secondSpawn; 
    public Transform thirdSpawn; 

    public float timeBetweenSpawns; // 4

    private int randomChoice;

    private float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0 && canSpawn) {
            spawnTimer = timeBetweenSpawns;
            SpawnSheep();
        }
    }

    private void SpawnSheep()
    {
        // Debug.Log(sheepSpawnPositions.Count);
        randomChoice = Random.Range(0, 3);

        if (randomChoice == 0){
            GameObject sheep = Instantiate(sheepPrefab, firstSpawn.position, sheepPrefab.transform.rotation);
        } else if (randomChoice == 1) {
            GameObject sheep = Instantiate(sheepPrefab, secondSpawn.position, sheepPrefab.transform.rotation);
        } else if (randomChoice == 2) {
            GameObject sheep = Instantiate(sheepPrefab, thirdSpawn.position, sheepPrefab.transform.rotation);
        }
    }
}
