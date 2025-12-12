using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private float _experienceToNextLevel = 100;
    private int _level = 1;
    private float _experience = 0f;
    private float _expMultiplier = 1.0f;

    private void Start()
    {
        var stats = GetComponent<StatManager>().PlayerStats;
        if (stats != null)
        {
            _expMultiplier = stats.ExpMultiplier;
        }
        else
        {
            Debug.LogWarning("PlayerStats not found on StatManager. Using default ExpMultiplier.");
        }
    }
    public void AddExperience(float exp)
    {
        if (_experienceToNextLevel <= 0) return;
        _experience += exp * _expMultiplier;

        //Debug.Log("Gained experience: " + exp + " Total experience: " + _experience);

        while (_experience >= _experienceToNextLevel)
        {
            _experience -= _experienceToNextLevel;
            LevelUp();
            //Debug.Log("Leveled up to: " + _level);
        }
    }

    private void LevelUp()
    {
        _level++;
        EventBus.Instance.OnLevelUp?.Invoke(_level);
    }
}
