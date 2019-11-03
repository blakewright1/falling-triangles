using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    float nextSpawnTime;
    public float secondsBetweenSpawns;
    Vector2 screenHalfSize;

    void Start()
    {
        screenHalfSize = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + secondsBetweenSpawns;
            spawn();
        }
    }

    void spawn()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSize.x, screenHalfSize.x), Random.Range(-screenHalfSize.y+(Camera.main.orthographicSize/3f), 0));
        Instantiate(platformPrefab, spawnPosition, Quaternion.Euler(0, 0, 0));
    }
}
