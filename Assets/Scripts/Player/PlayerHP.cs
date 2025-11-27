using UnityEngine;

public class PlayerHP : MonoBehaviour, IHP
{
    [SerializeField] private int _maxHP = 100;
    private int _currentHP;

    public int maxHP => _maxHP;

    public int currentHP => _currentHP;

    private void Start()
    {
        _currentHP = _maxHP;
    }
    public void TakeDamage(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            Die();
        }
        Debug.Log("Player took " + damage + " damage. Current HP: " + _currentHP);
    }
    private void Die()
    {
        EventBus.Instance.OnPlayerDeath?.Invoke();
        Debug.Log("Player has died.");
        gameObject.SetActive(false);
    }

    public void Heal(int amount)
    {
        _currentHP += amount;
        if (_currentHP > _maxHP)
        {
            _currentHP = _maxHP;
        }
        EventBus.Instance.OnPlayerHealing?.Invoke();
    }
}
