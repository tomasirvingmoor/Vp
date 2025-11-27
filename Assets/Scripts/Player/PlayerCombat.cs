using UnityEngine;

public class PlayerCombat : MonoBehaviour, IPlayerCombat
{
    [SerializeField] private GunHolder[] _gunHolders;
    public void EquipGun(GameObject newGunPregab, int gunHolderIndex)
    {
        if (_gunHolders.Length > 0 && gunHolderIndex >= 0)
        {
            _gunHolders[gunHolderIndex].EquipGun(newGunPregab);
            //Debug.Log($"Gun equipped in holder {gunHolderIndex}.");
        }
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

}
