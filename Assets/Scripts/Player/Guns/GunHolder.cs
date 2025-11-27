using UnityEngine;

public class GunHolder : MonoBehaviour
{
    private GameObject _gunPrefab;
    public bool IsEquipped => _gunPrefab != null;

    public void EquipGun(GameObject gunPrefab)
    {
        if (gunPrefab == null)
        {
            Debug.LogWarning("Trying to equip a null gun prefab.");
            return;
        }

        _gunPrefab = Instantiate(gunPrefab, transform.position, transform.rotation, transform);
    }
}
