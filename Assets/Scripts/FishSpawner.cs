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
