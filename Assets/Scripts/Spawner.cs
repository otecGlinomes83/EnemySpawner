using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;

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

            _spawnPoints[Random.Range(0, _spawnPoints.Count)].Spawn();
        }
    }
}