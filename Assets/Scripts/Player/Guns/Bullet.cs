using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private int _damage =100;
    private float _speed;
    private Rigidbody2D _rb;
    private float _lifeTime = 5f;
    private Vector2 _direction;
    private Vector2 _previosPosition;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
        _previosPosition = transform.position;  
    }

    public void Init(int damage, float speed, Vector2 dir)
    {
        _damage = damage > 0 ? damage : 100;
        _speed = speed > 0 ? speed : 100;
        _direction = dir;
        //Debug.Log($"Bullet initialized with damage {_damage} and speed {_speed} , dir {_direction}."); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var target = collision.GetComponent<EnemyHP>();
        if (target != null)
        {
            target.TakeDamage(_damage);
           //Debug.Log($"Bullet hit an enemy and dealt damage {_damage}.");
        }
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _direction * _speed * Time.fixedDeltaTime);
    }
}
