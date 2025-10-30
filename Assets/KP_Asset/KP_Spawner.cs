using UnityEngine;

public class KP_Spawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign your Prefab in the Inspector
    public int numberOfObjectsToSpawn = 5; // How many objects to spawn
    public float spawnAreaMinX = -5f; // Define your desired spawn area
    public float spawnAreaMaxX = 5f;
    public float spawnAreaMinY = -3f;
    public float spawnAreaMaxY = 3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnObjectsAtRandomPositions(); 
    }

    void SpawnObjectsAtRandomPositions()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            float randomX = Random.Range(spawnAreaMinX, spawnAreaMaxX);
            float randomY = Random.Range(spawnAreaMinY, spawnAreaMaxY);
            Vector2 randomSpawnPosition = new Vector2(randomX, randomY);

            Instantiate(objectToSpawn, randomSpawnPosition, Quaternion.identity);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
