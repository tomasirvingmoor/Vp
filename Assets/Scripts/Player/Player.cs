using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _gunPrefab;
    private IHP _playerHP;
    private IPlayerCombat _playerCombat;
    private PlayerMovement _playerMovement;

    private void Start()
    {
        _playerHP = GetComponent<IHP>();
        _playerCombat = GetComponent<IPlayerCombat>();
        _playerMovement = GetComponent<PlayerMovement>();
        if (_gunPrefab != null)
        {
            _playerCombat.EquipGun(_gunPrefab, 0);
            //Debug.Log("Gun equipped on player start.");
        }
    }

}
