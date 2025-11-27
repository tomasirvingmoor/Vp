using UnityEngine;

public class ThrowingKnife : Gun
{
    [SerializeField] private GameObject _knifePrefab;
    private Camera _mainCamera;
    void Start()
    {
        _mainCamera = Camera.main;
        Instantiate(_knifePrefab, transform);
    }

    
    void Update()
    {
        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPosition - _rb.position).normalized;
    }
}
