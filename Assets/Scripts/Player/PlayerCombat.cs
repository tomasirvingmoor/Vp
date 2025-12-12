using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private GunInventaty _inventary;
    [SerializeField] private GunHolder[] _gunHolders;

    private void Awake()
    {
        if (_inventary == null)
        {
            Debug.LogError("GunInventory is not assigned.");
            enabled = false;
            return;
        }

        if (_gunHolders == null || _gunHolders.Length == 0)
        {
            Debug.LogError("GunHolders are not assigned.");
            enabled = false;
            return;
        }

        _inventary = Instantiate(_inventary);
        _inventary.ItemAdded += AddGun;
    }


    public void EquipGun(GameObject newGunPregab, int gunHolderIndex)
    {
        if (gunHolderIndex < 0 || gunHolderIndex >= _gunHolders.Length)
            return;

        _gunHolders[gunHolderIndex].EquipGun(newGunPregab);
    }


    private void Start()
    {
        foreach (var gun in _inventary.Items)
        {
            if (gun == null)
                continue;

            var free = GetFreeElement();
            if (free != null)
                free.EquipGun(gun);
        }

        _inventary.ItemAdded += AddGun;
        EventBus.Instance.GiveGun += _inventary.AddGun;
    }


    private GunHolder GetFreeElement()
    {
        foreach (var item in _gunHolders)
        {
            if (!item.IsEquipped)
                return item;
        }

        return null;
    }

    private void AddGun(GameObject newGun) => GetFreeElement()?.EquipGun(newGun);

    private void OnDisable()
    {
        _inventary.ItemAdded -= AddGun;
        EventBus.Instance.GiveGun -= _inventary.AddGun;
    }
}
