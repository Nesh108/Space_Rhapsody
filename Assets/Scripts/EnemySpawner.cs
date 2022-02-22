using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject EnemyObject;

    [Header("Settings")]
    public float SpawnDelay = 1f;
    public Vector2 SpawnRange = new Vector2(-1f, 1f);

    private float _timer;

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        if(_timer >= SpawnDelay)
        {
            _timer = 0f;
            SpawnEnemy(EnemyObject);
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, new Vector2(Random.Range(SpawnRange.x, SpawnRange.y), transform.position.y), enemy.transform.rotation, null);
    }
}
