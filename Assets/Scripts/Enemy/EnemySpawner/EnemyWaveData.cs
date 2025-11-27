using UnityEngine;

[CreateAssetMenu(fileName = "EnemyWaveData", menuName = "Scriptable Objects/EnemyWaweData")]
public class EnemyWaveData : ScriptableObject
{
    [SerializeField] private GameObject _enemyPrefabs;
    [SerializeField] private float _spawnInterval;

    public GameObject EnemyPrefabs => _enemyPrefabs;
    public float SpawnInterval => _spawnInterval;
}
