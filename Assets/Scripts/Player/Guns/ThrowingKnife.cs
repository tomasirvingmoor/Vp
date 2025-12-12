using UnityEngine;

public class ThrowingKnife : Gun
{
    [SerializeField] private GameObject _knifePrefab;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _knifeSpeed = 10;
    private Camera _mainCamera;
    void Start()
    {
        _mainCamera = Camera.main;
    }

    
    void Update()
    {
        Vector2 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        LookToTarget(mouseWorldPosition);
        if (CanAttack)
            Attack(mouseWorldPosition);
        UpdateReload();
    }

    protected override void Attack(Vector2 target)
    {
        var spell = Instantiate(_knifePrefab, (Vector2)transform.position, Quaternion.identity);
        spell.transform.rotation = transform.rotation;
        if (spell.TryGetComponent<Bullet>(out var bullet))
        {
            var direction = (target - (Vector2)transform.position).normalized;
            bullet.Init(_damage, _knifeSpeed, direction);
        }
        else
            Debug.Log("Bullet is null");
    }
}
