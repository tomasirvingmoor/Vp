using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptable Objects/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private int _maxHP = 100;
    [SerializeField] private float _damageMultiplier = 1f;
    [SerializeField] private float _moveSpeedMultiplieir = 1f;
    [SerializeField] private float _expMultiplier = 1f;

    public float MoveSpeed => _moveSpeed;
    public int MaxHP => _maxHP;
    public float DamageMultiplier => _damageMultiplier;
    public float MoveSpeedMultiplieir => _moveSpeedMultiplieir;
    public float ExpMultiplier => _expMultiplier;
    

    public void ModifyDamageMultiplier(float delta)
    {
        _damageMultiplier += delta; 
    }
    
    public void ModifyMoveSpeedMultiplier(float delta)
    {
        _moveSpeedMultiplieir += delta;
    }
    public void ModifyExpMultiplier(float delta)
    {
        _expMultiplier += delta;
    }

    public void ModifyMaxHP(int delta)
    {
        _maxHP += delta;
    }
}
