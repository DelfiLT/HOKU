using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    public List<GameObject> objectsToPool;
    public List<List<GameObject>> listsToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start() 
    {
        GameObject tmp;
        listsToPool = new List<List<GameObject>>();

        foreach (GameObject gameObject in objectsToPool)     
        {
            List<GameObject> pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                tmp = Instantiate(gameObject);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);
            }

            listsToPool.Add(pooledObjects);
        }
    }

    //public GameObject GetPooledObject() 
    //{ 
    //    for (int i = 0; i < amountToPool; i++)
    //    { 
    //        if (!pooledObjects[i].activeInHierarchy)
    //        { 
    //            return pooledObjects[i]; 
    //        } 
    //    } 
    //    return null;
    //}
}
