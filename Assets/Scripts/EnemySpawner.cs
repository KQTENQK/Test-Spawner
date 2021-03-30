using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _enemySpawners;
    [SerializeField] private GameObject _prefabEnemy;
    [SerializeField] private int _enemyCount;

    private IEnumerator SpawnEnemy()
    {
        int spawnerIndex = 0;
        for(int i = 0; i < _enemyCount; i++, spawnerIndex++)
        {
            if (spawnerIndex > _enemySpawners.Length - 1)
                spawnerIndex = 0;

            Instantiate(_prefabEnemy, _enemySpawners[spawnerIndex].transform.position, Quaternion.identity);
            
            yield return new WaitForSeconds(2);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
}
