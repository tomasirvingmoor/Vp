using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyWaveData[] _enemyWaveData;
    [SerializeField] private int _startEnenyCount = 10;
    [SerializeField] private float _spawnRadius = 10;
    [SerializeField] private float _timeBetweenWaves = 10f;
    private ObjectPool _enemyPool;
    private Dictionary<EnemyType, ObjectPool> _pools;

    private void Start()
    {
        _pools = new Dictionary<EnemyType, ObjectPool>();

        foreach (var wave in _enemyWaveData)
        {
            var type = wave.EnemyPrefabs.GetComponent<Enemy>().EnemyType;
            if (!_pools.ContainsKey(type))
                _pools[type] = new ObjectPool(wave.EnemyPrefabs, transform, _startEnenyCount);
        }

        StartCoroutine(EnemyWaves());
    }


    private IEnumerator EnemyWaves()
    {
        foreach (var item in _enemyWaveData)
        {
            StartCoroutine(SpawnEnemies(item));
            //Debug.Log($"Start wave with {item.EnemyPrefabs.name}");
            yield return new WaitForSeconds(_timeBetweenWaves);
        }
    }

    private IEnumerator SpawnEnemies(EnemyWaveData item)
    {
        var enemyPrefab = item.EnemyPrefabs;
        var type = enemyPrefab.GetComponent<Enemy>().EnemyType;
        ObjectPool pool = _pools[type];
        float timer = 0f;
        while (timer < _timeBetweenWaves)
        {
            var enemy = pool.GetFreeElement();

            Vector2 spawnPoint = Random.insideUnitCircle * _spawnRadius;
            enemy.transform.position = (Vector2)transform.position + spawnPoint;

            yield return new WaitForSeconds(item.SpawnInterval);
            timer += item.SpawnInterval;
        }
        
    }
}
