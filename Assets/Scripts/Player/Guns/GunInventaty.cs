using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/GunInventory")]
public class GunInventaty : ScriptableObject
{
    public event Action<GameObject> ItemAdded;

    [SerializeField] private GameObject[] _items = new GameObject[6];

    
    public IReadOnlyList<GameObject> Items => _items;

    public void AddGun(GameObject newGun)
    {
        int freeIndex = FindFreeSlot();
        if (freeIndex < 0) return;

        _items[freeIndex] = newGun;

        // Вызываем событие
        ItemAdded?.Invoke(newGun);
    }

    private int FindFreeSlot()
    {
        for (int i = 0; i < _items.Length; i++)
            if (_items[i] == null)
                return i;

        return -1;
    }
}
