using UnityEngine;

public class EnemyMovement : MonoBehaviour, IEnemyMovement
{
    [SerializeField] private float _speed = 2f;
    public float speed => _speed;
    private Rigidbody2D _enemyRigitbody;

    private void Awake()
    {
        _enemyRigitbody = GetComponent<Rigidbody2D>();
    }

    public void MoveToTarget(Vector2 target)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        _enemyRigitbody.MovePosition(_enemyRigitbody.position + direction * _speed * Time.fixedDeltaTime);
    }
}

