using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemySpawnPoints;
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private int _enemyCount;
    [SerializeField] private float _spawnDelay;

    private IEnumerator SpawnEnemy()
    {
        int spawnerIndex = 0;
        for(int i = 0; i < _enemyCount; i++, spawnerIndex++)
        {
            if (spawnerIndex > _enemySpawnPoints.Length - 1)
                spawnerIndex = 0;

            Instantiate(_prefabEnemy, _enemySpawnPoints[spawnerIndex].transform.position, Quaternion.identity);
            
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
}
