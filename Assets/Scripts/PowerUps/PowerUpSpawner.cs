using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public FactoryPowerUp factory;
    [SerializeField] private Transform spawn;

    public void SpawnPowerUp()
    {
        factory.createPowerUp("Shield", spawn);
    }
}
