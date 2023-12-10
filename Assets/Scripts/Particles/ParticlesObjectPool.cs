using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesObjectPool : MonoBehaviour
{
    public static ParticlesObjectPool ParticleInstance;

    public List<GameObject> particlesToPool;
    public Dictionary<string, List<GameObject>> listsToPoolparticles;
    private int amountToPool;

    void Awake()
    {
        ParticleInstance = this;
        amountToPool = 0;
    }

    void Start()
    {
        listsToPoolparticles = new Dictionary<string, List<GameObject>>();
        GameObject poolObject;

        foreach (GameObject gameObject in particlesToPool)
        {
            string name = gameObject.GetComponent<ParticlesScript>().particleType.ToString();
            amountToPool = gameObject.GetComponent<ParticlesScript>().poolAmmount;

            List<GameObject> pooledObjects = new List<GameObject>();
            for (int i = 0; i < amountToPool; i++)
            {
                poolObject = Instantiate(gameObject);
                poolObject.SetActive(false);
                pooledObjects.Add(poolObject);
                poolObject.transform.parent = transform;
            }
            listsToPoolparticles.Add(name, pooledObjects);
        }
    }

    public GameObject GetPooledObject(string particleType)
    {
        if (particleType == null || particleType == "")
        {
            return null;
        }

        foreach (GameObject gameObject in listsToPoolparticles[particleType])
        {
            if (!gameObject.activeInHierarchy)
            {
                return gameObject;
            }
        }
        return null;
    }
}

