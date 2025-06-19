using Unity.VisualScripting;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs;

    float spawnRangeX = 15.0f;

    public float startDelay = 2.0f;

    public float spawnInterval = 2.0f;

    void Start()
    {
        InvokeRepeating("SpawnRandomTrash", startDelay, spawnInterval);
    }


    void Update()
    {

    }

    void SpawnRandomTrash()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 12, 0);

        int trashIndex = Random.Range(0, trashPrefabs.Length);
        Instantiate(trashPrefabs[trashIndex], spawnPos, trashPrefabs[trashIndex].transform.rotation);
    }
}