using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fishPrefab;
    [SerializeField] private float spawnInterval = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnFish), 0f, spawnInterval);
    }

    private void SpawnFish()
    {
        Vector3 spawnPosition = new Vector3(11f, 0f, 0f);
        Quaternion spawnRotation = Quaternion.Euler(0f, -180f, 0f);
        Instantiate(fishPrefab, spawnPosition, spawnRotation);
    }
}
