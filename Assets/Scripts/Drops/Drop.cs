using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Drop : MonoBehaviour
{
    [SerializeField] private float _attractionSpeed = 5f;
    public bool IsMoving => _moveRoutine != null;

    private Rigidbody2D _rb;
    private Coroutine _moveRoutine;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void GoToPlayer(Transform target)
    {
        //Debug.Log("Drop moving");
        if (_moveRoutine != null || target == null) return;
        _moveRoutine = StartCoroutine(MoveToPlayer(target));
    }

    private IEnumerator MoveToPlayer(Transform target)
    {
        while (target != null &&
               (target.position - transform.position).sqrMagnitude > 0.25f)
        {
            var dir = (Vector2)(target.position - transform.position).normalized;
            _rb.MovePosition(_rb.position + dir * _attractionSpeed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }

        _moveRoutine = null;
    }
}
