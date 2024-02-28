using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnInterval;
    [SerializeField] PlayerController playerController;
    [SerializeField] float size;

    float spawnCooldown;

    [SerializeField] private List<Enemy> enemyPrefabs;


    private void Start()
    {
        spawnCooldown = spawnInterval;
    }

    void Update()
    {
        if(spawnCooldown > 0)
        {
            spawnCooldown -= Time.deltaTime;
            if(spawnCooldown <= 0)
            {
                spawnCooldown = spawnInterval;
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        
        Instantiate(
            enemyPrefabs[Random.Range(0, enemyPrefabs.Count)], 
            GetPosition(), 
            Quaternion.identity
            );
    }

    Vector3 GetPosition()
    {
        Vector3 pos = new Vector3(1, 1, 1);
        if (playerController.transform.position.x > 0)
            pos.x *= -1;

        if (playerController.transform.position.z > 0)
            pos.z *= -1;

        // pos = (-1,0,1)
        pos.x *= Random.Range(size/2, size);
        pos.z *= Random.Range(size/2, size);

        return pos;
    }
}
