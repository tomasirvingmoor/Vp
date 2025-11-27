using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private GameObject prefab;
    private Transform container;

    private List<GameObject> objects;

    public ObjectPool(GameObject prefab, Transform conteiner, int count)
    {
        this.prefab = prefab;
        this.container = conteiner;
        objects = new List<GameObject>(count);

        if (count <= 0)
            CreatePool(5);
        else
            CreatePool(count);
    }

    public void SetNewPrefab(GameObject newPrefab)
    {
        if (newPrefab)
            prefab = newPrefab;
    }

    private void CreatePool(int count)
    {
        for (int i = 0; i < count; i++)
            objects.Add(CreateObjects());
    }

    private GameObject CreateObjects(bool DefaultSetActive = false)
    {
        var obg = Object.Instantiate(prefab, container);
        obg.gameObject.SetActive(DefaultSetActive);
        return obg;
    }

    private bool HasFreeElements(out GameObject element)
    {
        foreach (var item in objects)
        {
            if (item != null && !item.activeInHierarchy)
            {
                element = item;
                item.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public GameObject GetFreeElement()
    {
        if (HasFreeElements(out var element))
            return element;
        else
            return CreateObjects(true);

    }

    public void GetElementForType(EnemyType enemyType, out GameObject element)
    {
        foreach (var item in objects)
        {
            if (item != null && !item.activeInHierarchy)
            {
                var enemy = item.GetComponent<Enemy>();
                if (enemy != null && enemy.EnemyType == enemyType)
                {
                    element = item;
                    item.SetActive(true);
                    return;
                }
            }
        }
        element = CreateObjects(true);
    }
}
