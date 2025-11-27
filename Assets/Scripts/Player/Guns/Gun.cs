using UnityEngine;

public class Gun : MonoBehaviour
{    
    [SerializeField] private float _reloadTime = 1.0f;
    [SerializeField] private float _radius = 10;
    [SerializeField] private float _rotationSpeed = 5.0f;
    [SerializeField] private LayerMask _enemyLayer;
    private Collider2D[] _targets = new Collider2D[20];
    private float _reloadTimer = 0f;

    protected virtual void Attack(Vector2 target)
    {
        LookToTarget(target);
    }

    protected void LookToTarget(Vector2 target)
    {
        var dir  = (target - (Vector2)transform.position).normalized;

        if (dir == Vector2.zero) return;

        transform.rotation = Quaternion.Slerp(transform.rotation,
            Quaternion.LookRotation(Vector3.forward, dir),
            _rotationSpeed * Time.deltaTime);
    }
    protected bool TryGetTarget(out Vector2 target)
    {
        var hits = Physics2D.OverlapCircleNonAlloc(transform.position, _radius, _targets, _enemyLayer);
        for (int i = 0; i < hits; i++)
        {
            var enemy = _targets[i];
            if (enemy != null && enemy.gameObject.activeInHierarchy)
            {
                target = enemy.transform.position;
                return true;
            }
        }

        target = Vector2.zero;
        return false;
    }

    protected bool CanAttack => _reloadTimer <= 0f;

    protected void UpdateReload()
    {
        if (_reloadTimer > 0f)
            _reloadTimer -= Time.deltaTime;
        else
            _reloadTimer = _reloadTime;
    }

}
