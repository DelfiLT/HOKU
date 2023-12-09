using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Enemies")]
    public EnemiesFactory EnemiesFactory;
    public Transform[] EnemiesSpawns;
    public EnemyType[] EnemiesTypes;

    [Header("PowerUps")]
    public FactoryPowerUp PowerUpsFactory;
    public PowerUpType[] PowerUpTypes;
    public Transform[] PowerUpsSpawn;

    [Header("Weapons")]
    public GameObject[] weapons;

    public void SpawnEnemy()
    {
        EnemiesFactory.CreateEnemy(EnemiesTypes[Random.Range(0, EnemiesTypes.Length)].ToString(), EnemiesSpawns[Random.Range(0, EnemiesSpawns.Length)]);
    }

    public void SpawnPowerUp()
    {
        PowerUpsFactory.CreatePowerUp(PowerUpTypes[Random.Range(0, PowerUpTypes.Length)].ToString(), PowerUpsSpawn[Random.Range(0,PowerUpsSpawn.Length)]);
    }

    public void SpawnWeapon()
    {
        Instantiate(weapons[Random.Range(0, weapons.Length)], PowerUpsSpawn[Random.Range(0, PowerUpsSpawn.Length)].position, Quaternion.identity);
    }
}
