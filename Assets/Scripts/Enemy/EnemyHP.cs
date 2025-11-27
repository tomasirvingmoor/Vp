using System;
using UnityEngine;

public class EnemyHP : MonoBehaviour, IHP
{
    [SerializeField] private int _maxHP = 10;
    private int _currentHP;

    public int maxHP => throw new System.NotImplementedException();

    public int currentHP => throw new System.NotImplementedException();

    void Start()
    {
        _currentHP = _maxHP;
    }
    private void Die()
    {
        Debug.Log("Enemy died");
        EventBus.Instance.OnEnemyDeath?.Invoke();
        SpawnExpShard();
        Destroy(gameObject);
    }

    private void SpawnExpShard()
    {
        var shard = ExpShardPool.Instance.GetExpShard();
        shard.transform.position = transform.position;
    }

    public void TakeDamage(int damage)
    {
        _currentHP = _currentHP - damage;
        if (_currentHP <= 0)
        {
            Die();
        }
        //Debug.Log($"{damage} {_currentHP}");
    }
}
