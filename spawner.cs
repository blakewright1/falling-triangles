using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject fallingTrianglePrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    float nextSpawnTime;
    public float spawnAngleMax;
    Vector2 screenHalfSize;

    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize + 1);  
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.getDifficultyPercent());
            float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), screenHalfSize.y+2);
            Instantiate(fallingTrianglePrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
        }
    }

    
}
