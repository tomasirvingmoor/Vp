using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private float _playerSpeed = 5f;
    private Rigidbody2D _rb;
    private Camera _mainCamera;
    private float _speedMultipliers =1f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
        UpdateMovementStats();
    }

    private void UpdateMovementStats()
    {
        var stats = GetComponent<StatManager>();
        if (stats != null)
        {
            _playerSpeed = stats.PlayerStats.MoveSpeed;
            _speedMultipliers *= stats.PlayerStats.MoveSpeedMultiplieir;
            Debug.Log("Give moveSpeed and speedMultiplier by player stats");
        }
        else
        {
            Debug.Log("Using Default stats");
        }
    }

    private void FixedUpdate()
    {
        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPosition - _rb.position).normalized;
        if(Vector2.Distance(mouseWorldPosition, _rb.position) < 0.1f)
        {
            direction = Vector2.zero;
        }
        _rb.MovePosition(_rb.position + direction * _playerSpeed * Time.fixedDeltaTime * _speedMultipliers);
    }
}
