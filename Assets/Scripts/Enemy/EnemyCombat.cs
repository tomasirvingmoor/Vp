using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _attackCooldown = 1f;

    private float _timer = 0f;

    public int damage => _damage;
    protected bool Ready => _timer <= 0f;

    protected virtual void Attack() { }

    protected void TickCooldown()
    {
        if (_timer > 0)
            _timer -= Time.deltaTime;
    }

    protected void ResetCooldown()
    {
        _timer = _attackCooldown;
    }
}
