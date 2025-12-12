using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance { get; private set; }
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Action<int> OnDamage;
    public Action OnPlayerDeath;
    public Action OnPlayerHealing;
    public Action OnPlayerReady;
    public Action OnEnemyDeath;
    public Action<int> OnLevelUp;
    public Action<BuffType, float> BuffCharacter;
    public Action UpdateCharacterStats;
    public Action<GameObject> GiveGun;
}
