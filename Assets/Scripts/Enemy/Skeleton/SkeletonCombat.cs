using UnityEngine;

public class SkeletonCombat : EnemyCombat
{
    [SerializeField] private EnemyAttackHitbox _hitBox;

    void Update()
    {
        TickCooldown();

        if (Ready && _hitBox.PlayerHP != null)
        {
            Attack();
            ResetCooldown();
        }
    }

    protected override void Attack()
    {
        _hitBox.PlayerHP?.TakeDamage(damage);
    }
}
