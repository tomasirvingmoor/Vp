using UnityEngine;

public class PlayerDrop : MonoBehaviour
{
    [SerializeField] private float _attractionRadius = 5f;
    [SerializeField] private LayerMask _dropLayer;

    private readonly Collider2D[] _results = new Collider2D[32];

    private void Start()
    {
        Debug.Log("PlayerDrop started");
    }

    private void Update()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, _attractionRadius, _results, _dropLayer);

        //if (count > 0) Debug.Log("Drop exist");
        //else Debug.Log("Drop no exist");
        for (int i = 0; i < count; i++)
        {
            if (_results[i].TryGetComponent<Drop>(out var drop))
                drop.GoToPlayer(transform);
        }
    }
}
