using System.Collections;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fishPrefab;

    [SerializeField] private float initialSpawnInterval = 2f;
    [SerializeField] private float minSpawnInterval = 0.5f;
    [SerializeField] private float intervalDecreaseRate = 0.1f;


    private float spawnInterval;
    
    private void Start()
    {
        spawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnFishLoop());
    }

    private IEnumerator SpawnFishLoop()
    {
        while (true)
        {
            SpawnFish();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator DecreaseInterval()
    {
        while (spawnInterval > minSpawnInterval) {
            yield return new WaitForSeconds(10f);
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseRate);
        }
    }
    
    private void SpawnFish()
    {
        // Pilih secara random spawn dari kiri atau kanan
        bool spawnFromLeft = Random.Range(0, 2) == 0;
        
        Vector3 spawnPosition;
        Quaternion spawnRotation;
        
        if (spawnFromLeft)
        {
            // Spawn dari kiri, bergerak ke kanan
            spawnPosition = new Vector3(-20f, Random.Range(-9f, 9f), 0f);
            spawnRotation = Quaternion.identity; // Menghadap kanan
        }
        else
        {
            // Spawn dari kanan, bergerak ke kiri
            spawnPosition = new Vector3(20f, Random.Range(-9f, 9f), 0f);
            spawnRotation = Quaternion.Euler(0f, 180f, 0f); // Menghadap kiri
        }
        
        Instantiate(fishPrefab, spawnPosition, spawnRotation);
    }
}
