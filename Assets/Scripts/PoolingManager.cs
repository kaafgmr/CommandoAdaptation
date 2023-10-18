using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PooledItem
{
    public string Name;
    public GameObject objectToPool;
    public int amount;
}

public class PoolingManager : MonoBehaviour
{
    public List<GameObject> TotalObjects;

    private static PoolingManager _instance;
    public static PoolingManager Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<PoolingManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<PooledItem> pooledLists = new List<PooledItem>();

    [SerializeField]
    private Dictionary<string, List<GameObject>> _items = new Dictionary<string, List<GameObject>>();

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }

        TotalObjects = new List<GameObject>();

        foreach (PooledItem pooledItem in pooledLists)
        {
            _items.Add(pooledItem.Name, new List<GameObject>());

            for (int j = 0; j < pooledItem.amount; j++)
            {
                AddItemToList(pooledItem.objectToPool, pooledItem.Name);
            }
        }
    }

    private void AddItemToList(GameObject itemToAdd, string itemName)
    {
        GameObject tmp = Instantiate(itemToAdd);
        tmp.SetActive(false);
        _items[itemName].Add(tmp);
        TotalObjects.Add(tmp);
    }

    public GameObject GetPooledObject(string name)
    {
        List<GameObject> tmp = _items[name];
        for(int i = 0; i < tmp.Count; i++)
        {
            if(!tmp[i].activeInHierarchy)
            {
                tmp[i].SetActive(true);
                return tmp[i];
            }
        }
        GameObject newObject = tmp[0];
        AddItemToList(newObject, name);
        newObject.SetActive(true);
        return newObject;
    }

    public void DisableAllObjects()
    {
        for (int i = 0; i < TotalObjects.Count; i++)
        {
            TotalObjects[i].SetActive(false);
        }
    }
}