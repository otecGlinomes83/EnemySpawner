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
        if (_spawnPoints.Count != 0)
            StartCoroutine(SpawnEnemyAtTime());
    }

    private IEnumerator SpawnEnemyAtTime()
    {
        WaitForSecondsRealtime wait = new WaitForSecondsRealtime(_spawnRate);

        while (isActiveAndEnabled)
        {
            yield return wait;

            Enemy enemy = Instantiate
                (
                _enemyPrefab,
                _spawnPoints[Random.Range(0, _spawnPoints.Count)].position,
                Quaternion.identity
                );

            enemy.StartMove(GenerateRandomRoute());
        }
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