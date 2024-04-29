using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefabs;
    public float obstacleSpawnTime = 2f;
    [SerializeField] private float spawnTimeMin = 2f;
    [SerializeField] private float spawnTimeMax = 6f;

    private float timeUntilObstacleSpawn;

    // Update is called once per frame
    private void Update()
    {
        SpawnLoop();

    }

    private void SpawnLoop()
    {
        timeUntilObstacleSpawn += Time.deltaTime;

        if (timeUntilObstacleSpawn >= obstacleSpawnTime)
        {
            Spawn();

            obstacleSpawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
            timeUntilObstacleSpawn = 0f;

        }

    }
    private void Spawn()
    {
        if (gameObject.transform.position.z == 105f)
        {
            GameObject obstacleToSpawn = obstaclePrefabs;

            GameObject spawnedObstacle = Instantiate(obstacleToSpawn, new Vector3(Random.Range(-25f, 25f), Random.Range(3f, 3f), 105), Quaternion.identity);

            Rigidbody obstacleRB = spawnedObstacle.GetComponent<Rigidbody>();

            spawnedObstacle.layer = LayerMask.NameToLayer("Enemy");
        }

        if (gameObject.transform.position.z == -105f)
        {
            GameObject obstacleToSpawn = obstaclePrefabs;

            GameObject spawnedObstacle = Instantiate(obstacleToSpawn, new Vector3(Random.Range(-25f, 25f), Random.Range(3f, 3f), -105), Quaternion.identity);

            Rigidbody obstacleRB = spawnedObstacle.GetComponent<Rigidbody>();

            spawnedObstacle.layer = LayerMask.NameToLayer("Enemy");
        }
    }
}
