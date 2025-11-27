using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class ExpShard : MonoBehaviour
{
    [SerializeField] private float _expCount = 10;
    [SerializeField] private float _attractionRadius = 5f;
    [SerializeField] private float _attractionSpeed = 7f;
    [SerializeField] private LayerMask _playerLayer;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var player = Physics2D.OverlapCircle(transform.position, _attractionRadius, _playerLayer);

        if (player == null)
            return;

        Vector2 dir = (player.transform.position - transform.position).normalized;

        Vector2 newPos = _rb.position + dir * _attractionSpeed * Time.fixedDeltaTime;
        _rb.MovePosition(newPos);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerLevel>(out var playerLvl))
        {
            playerLvl.AddExperience(_expCount);
            gameObject.SetActive(false);
        }
    }
}


