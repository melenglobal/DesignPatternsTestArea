using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    
    public int amounth;

    public bool expandable;
}
public class Pool : MonoBehaviour
{
    public static Pool singleton;

    public List<PoolItem> items;

    public List<GameObject> pooledItems;

    private void Awake()
    {
        singleton = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledItems = new List<GameObject>();

        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amounth; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                
                obj.SetActive(false);
                
                pooledItems.Add(obj);
            }
        }
    }

    public GameObject Get(string tag)
    {
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (!pooledItems[i].activeInHierarchy && pooledItems[i].tag == tag)
            {
                return pooledItems[i];
            }
        }

        
        foreach (PoolItem item in items)
        {
            if (item.expandable && item.prefab.tag == tag)
            {
                for (int i = 0; i < item.amounth; i++)
                {
                    GameObject obj = Instantiate(item.prefab);
                    
                    obj.SetActive(false);
                    
                    pooledItems.Add(obj);
                }
            }
             
        }

        return null;
    }

}