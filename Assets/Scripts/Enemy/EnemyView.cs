using UnityEngine;

public class EnemyView : MonoBehaviour
{
    [SerializeField] private float _viewRadius = 10f;
    [SerializeField] private LayerMask _playerLayer;

    public Vector2 playerPosition { get; private set; }
    public bool canSeePlayer => playerPosition != (Vector2)transform.position;

    private void Update()
    {
        DetectPlayer();
    }

    private void DetectPlayer()
    {
        Collider2D playerCollider = Physics2D.OverlapCircle(transform.position, _viewRadius, _playerLayer);
        if (playerCollider != null && playerCollider.CompareTag("Player"))
        {
            playerPosition = playerCollider.transform.position;
        }
        else
        {
            playerPosition = transform.position;
        }
    }
}