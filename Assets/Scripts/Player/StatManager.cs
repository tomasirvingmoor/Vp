using UnityEngine;

public class StatManager : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    public PlayerStats PlayerStats => _playerStats;

    private void Awake()
    {
        UpdateStats();
    }


    private void UpdateStats()
    {
        _playerStats = Instantiate(_playerStats);
    }

    private void Start()
    {
        EventBus.Instance.BuffCharacter += ApplyBuff;
        EventBus.Instance.UpdateCharacterStats += UpdateStats;
    }


    private void ApplyBuff(BuffType buffType, float value)
    {
        switch (buffType)
        {
            case BuffType.DamageMultiplier:
                _playerStats.ModifyDamageMultiplier(value);
                break;
            case BuffType.MoveSpeedMultiplier:
                _playerStats.ModifyMoveSpeedMultiplier(value);
                break;
            case BuffType.ExpMultiplier:
                _playerStats.ModifyExpMultiplier(value);
                break;
            case BuffType.MaxHP:
                // Assuming MaxHP is an integer value
                _playerStats.ModifyMaxHP((int)value);
                break;
            default:
                Debug.LogWarning("Unknown buff type");
                break;
        }
    }
    private void OnDisable()
    {
        EventBus.Instance.BuffCharacter -= ApplyBuff;
        EventBus.Instance.UpdateCharacterStats -= UpdateStats;
    }
}

public enum BuffType
{
    DamageMultiplier,
    MoveSpeedMultiplier,
    ExpMultiplier,
    MaxHP,
}