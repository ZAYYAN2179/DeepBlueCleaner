using Unity.VisualScripting;
using UnityEngine;

public class ChestSpawner : MonoBehaviour
{
    public GameObject[] chestPrefabs;

    float spawnRangeX = 15.0f;

    public float startDelay = 2.0f;

    public float spawnInterval = 2.0f;

    void Start()
    {
        InvokeRepeating("SpawnRandomChest", startDelay, spawnInterval);
    }


    void Update()
    {

    }

    void SpawnRandomChest()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 12, 0);

        int trashIndex = Random.Range(0, chestPrefabs.Length);
        Instantiate(chestPrefabs[trashIndex], spawnPos, chestPrefabs[trashIndex].transform.rotation);
    }
}
