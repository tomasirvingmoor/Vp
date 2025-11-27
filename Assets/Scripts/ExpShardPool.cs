using UnityEngine;

public class ExpShardPool : MonoBehaviour
{
    [SerializeField] private GameObject _expShardPrefab;
    private ObjectPool _expShardPool;
    public static ExpShardPool Instance;
    void Start()
    {
        if (_expShardPrefab == null) return;

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        _expShardPool = new ObjectPool(_expShardPrefab, transform, 20);
    }

    public GameObject GetExpShard() => _expShardPool.GetFreeElement();
}
