using UnityEngine;

public class WizardStick: Gun
{
    [SerializeField] private GameObject _spellPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private int _damage;
    [SerializeField] private float _spellSpeed;
    private void Update()
    {
        if (TryGetTarget(out var target))
        {
            LookToTarget(target);
            if (CanAttack)
            {
                Attack(target);
            }
        }
        UpdateReload();
    }

    protected override void Attack(Vector2 target)
    {

        var spell = Instantiate(_spellPrefab, _firePoint.position, Quaternion.identity);
        if (spell.TryGetComponent<Bullet>(out var bullet))
        { 
            var direction = (target - (Vector2)_firePoint.position).normalized;
            bullet.Init(_damage, _spellSpeed, direction);
        }
        else
            Debug.Log("Bullet is null");
    }
}
