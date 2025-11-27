using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 5f;
    private Rigidbody2D _rb;
    private Camera _mainCamera;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _mainCamera = Camera.main;
    }

    private void FixedUpdate()
    {
        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPosition - _rb.position).normalized;
        if(Vector2.Distance(mouseWorldPosition, _rb.position) < 0.1f)
        {
            direction = Vector2.zero;
        }
        _rb.MovePosition(_rb.position + direction * _playerSpeed * Time.fixedDeltaTime);
    }
}
