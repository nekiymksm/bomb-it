using System.Collections.Generic;
using UnityEngine;

public class ItemsPool
{
    private Transform _creationTransform;
    private List<GameObject> _itemsPool;

    public void LoadItemsPool(GameObject prefab, Transform creationTransform, int itemsCount)
    {
        _creationTransform = creationTransform;
        _itemsPool = new List<GameObject>();

        for (int i = 0; i < itemsCount; i++)
        {
            _itemsPool.Add(Object.Instantiate(prefab, creationTransform));
            _itemsPool[i].gameObject.SetActive(false);
        }
    }

    public void RefreshItemsPool()
    {
        foreach (var item in _itemsPool)
        {
            item.gameObject.SetActive(false);
            item.transform.SetParent(_creationTransform);
        }
    }

    public GameObject TryGetItem()
    {
        foreach (var item in _itemsPool)
        {
            if (item.gameObject.activeSelf == false)
            {
                item.gameObject.SetActive(true);
                
                return item;
            }
        }

        return null;
    }
}