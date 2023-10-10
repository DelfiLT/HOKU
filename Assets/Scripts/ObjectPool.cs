using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    public List<GameObject> objectsToPool;
    public Dictionary<string, List<GameObject>> listsToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start() 
    {
        listsToPool = new Dictionary<string, List<GameObject>>();
        GameObject tmp;

        foreach (GameObject gameObject in objectsToPool)     
        {
            List<GameObject> pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(gameObject);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }

            listsToPool.Add(gameObject.tag, pooledObjects);
        }
    }

    public GameObject GetPooledObject(string bulletType)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!listsToPool[bulletType][i].activeInHierarchy)
            {
                if(listsToPool[bulletType] != null)
                {
                    return listsToPool[bulletType][i];
                }
                return null;
            }
        }
        return null;
    }
}
