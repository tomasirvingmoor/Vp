using UnityEngine;

public class PlayerHP : MonoBehaviour, IHP
{
    private int _maxHP = 100;
    private int _currentHP;

    public int maxHP => _maxHP;

    public int currentHP => _currentHP;

    private void Start()
    {
        var stats = GetComponent<StatManager>().PlayerStats;
        if (stats != null)
        {
            _maxHP = stats.MaxHP;
            _currentHP = _maxHP;
            //Debug.Log("Player MaxHP set to: " + _maxHP);
        }
        else
        {
            Debug.LogWarning("PlayerStats not found on StatManager. Using default MaxHP.");
        }
    }
    public void TakeDamage(int damage)
    {
        _currentHP -= damage;
        if (_currentHP <= 0)
        {
            Die();
        }
        //Debug.Log("Player took " + damage + " damage. Current HP: " + _currentHP);
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
