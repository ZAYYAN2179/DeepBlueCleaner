using System.Collections;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
    public GameObject[] trashPrefabs;

    float spawnRangeX = 15.0f;

    public float initialSpawnInterval = 2.0f;
    public float minSpawnInterval = 0.5f;
    public float intervalDecreaseRate = 0.1f;
    public float spawnInterval;

    private void Start()
    {
        spawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnTrashLoop());
        StartCoroutine(DecreaseSpawnInterval());
    }

    private IEnumerator SpawnTrashLoop()
    {
        yield return new WaitForSeconds(2.0f); // Delay awal
        while (true)
        {
            SpawnRandomTrash();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private IEnumerator DecreaseSpawnInterval()
    {
        while (spawnInterval > minSpawnInterval)
        {
            yield return new WaitForSeconds(10f); // tiap 10 detik
            spawnInterval = Mathf.Max(minSpawnInterval, spawnInterval - intervalDecreaseRate);
        }
    }

    private void SpawnRandomTrash()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 12, 0);

        int trashIndex = Random.Range(0, trashPrefabs.Length);
        Instantiate(trashPrefabs[trashIndex], spawnPos, trashPrefabs[trashIndex].transform.rotation);
    }
}
