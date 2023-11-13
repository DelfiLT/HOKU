using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FactoryPowerUp : MonoBehaviour
{
    [SerializeField] private PowerUps[] powerUps;
    private Dictionary<string, PowerUps> powerUpsDictionary;

    private void Awake()
    {
        powerUpsDictionary = new Dictionary<string, PowerUps>();
        foreach (var powerUp in powerUps)
        {
            powerUpsDictionary.Add(powerUp.powerUpName, powerUp);
        }
    }

    public PowerUps createPowerUp(string powerUpName, Transform spawn)
    {
        if(powerUpsDictionary.TryGetValue(powerUpName, out PowerUps powerPrefab))
        {
            PowerUps powerUpInstance = Instantiate(powerPrefab, spawn.position, Quaternion.identity);
            return powerUpInstance;
        }

        else
        {
            Debug.LogWarning($"The object '{powerUpName}' doesn´t exist in the data base.");
            return null;
        }
    }
}
