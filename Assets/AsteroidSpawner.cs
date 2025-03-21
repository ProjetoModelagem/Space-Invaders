using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab; // Prefab do asteroide
    public float spawnRate = 2f; // Tempo entre spawns
    public float spawnYMin = -3f; // Limite inferior de spawn
    public float spawnYMax = 3f; // Limite superior de spawn

    void Start()
    {
        InvokeRepeating("SpawnAsteroid", 2f, spawnRate);
    }

    void SpawnAsteroid()
    {
        float spawnY = Random.Range(spawnYMin, spawnYMax);
        Vector3 spawnPosition = new Vector3(10, spawnY, 0); // Fora da tela à direita
        Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
    }
}



