using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private List<Transform> _spawnPoints;

    private float _spawnRate = 2f;

    private void Start()
    {
        StartCoroutine(SpawnEnemyAtTime());
    }

    private IEnumerator SpawnEnemyAtTime()
    {
        while (isActiveAndEnabled)
        {
            yield return new WaitForSecondsRealtime(_spawnRate);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        if (TryGetRandomSpawnpoint(out Transform spawnpoint))
        {
            Enemy enemy = Instantiate(_enemyPrefab, spawnpoint.position, Quaternion.identity);
            enemy.Initialize(GenerateRandomRoute());

            return;
        }
    }

    private bool TryGetRandomSpawnpoint(out Transform spawnpoint)
    {
        if (_spawnPoints.Count == 0)
        {
            spawnpoint = null;
            return false;
        }

        spawnpoint = _spawnPoints[Random.Range(0, _spawnPoints.Count)];
        return true;
    }

    private Vector3 GenerateRandomRoute()
    {
        List<Vector3> routes = new List<Vector3>
        {
            Vector3.forward,
            Vector3.back,
            Vector3.right,
            Vector3.left
        };

        return routes[Random.Range(0, routes.Count)];
    }
}