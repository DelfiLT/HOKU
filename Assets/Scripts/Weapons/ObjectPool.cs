using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;

    public List<GameObject> objectsToPool;
    public Dictionary<string, List<GameObject>> listsToPool;
    private int amountToPool;

    void Awake()
    {
        SharedInstance = this;
        amountToPool = 0;
    }

    void Start() 
    {
        listsToPool = new Dictionary<string, List<GameObject>>();
        GameObject poolObject;

        foreach (GameObject gameObject in objectsToPool)     
        {
            string name = gameObject.GetComponent<Bullet>().weaponType.ToString();
            amountToPool = gameObject.GetComponent<Bullet>().poolAmmount;

            List<GameObject> pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                poolObject = Instantiate(gameObject);
                poolObject.SetActive(false);
                pooledObjects.Add(poolObject);
                poolObject.transform.parent = transform;
            }

            listsToPool.Add(name, pooledObjects);
        }
    }

    public GameObject GetPooledObject(string bulletType)
    {
        foreach (GameObject gameObject in listsToPool[bulletType])
        {
            if (!gameObject.activeInHierarchy)
            {
                return gameObject;
            }
        }

        return null;
    }
}
