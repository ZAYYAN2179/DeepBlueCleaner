using System.Collections;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fishPrefab;

    [SerializeField] private float initialSpawnInterval = 10f;
    [SerializeField] private float minSpawnInterval = 2f;
    [SerializeField] private float intervalDecreaseRate = 1f;

    private float spawnInterval;
    private int fishPerSpawn = 1; // Mulai dengan 1 ikan

    private void Start()
    {
        spawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnFishLoop());
        StartCoroutine(DecreaseInterval());
        StartCoroutine(IncreaseFishPerSpawn()); // Tambahkan ini
    }

    private IEnumerator SpawnFishLoop()
    {
        while (true)
        {
            for (int i = 0; i < fishPerSpawn; i++)
            {
                SpawnFish();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator DecreaseInterval()
    {
        while (spawnInterval > minSpawnInterval)
        {
            yield return new WaitForSeconds(20f);
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseRate);
            Debug.Log("Spawn interval now: " + spawnInterval);
        }
    }

    private IEnumerator IncreaseFishPerSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(30f);
            fishPerSpawn++;
            Debug.Log("Fish per spawn increased to: " + fishPerSpawn);
        }
    }

    private void SpawnFish()
    {
        bool spawnFromLeft = Random.Range(0, 2) == 0;

        Vector3 spawnPosition;
        Quaternion spawnRotation;

        if (spawnFromLeft)
        {
            spawnPosition = new Vector3(-20f, Random.Range(-9f, 9f), 0f);
            spawnRotation = Quaternion.identity;
        }
        else
        {
            spawnPosition = new Vector3(20f, Random.Range(-9f, 9f), 0f);
            spawnRotation = Quaternion.Euler(0f, 180f, 0f);
        }

        Instantiate(fishPrefab, spawnPosition, spawnRotation);
    }
}
