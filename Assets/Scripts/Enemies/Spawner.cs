using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemiesFactory EnemiesFactory;
    public Transform[] EnemiesSpawns;

    public void SpawnBomber()
    {
        EnemiesFactory.CreateEnemy(EnemyType.Bomber.ToString(), EnemiesSpawns[1]);
    }

    public void SpawnShooter()
    {
        EnemiesFactory.CreateEnemy(EnemyType.Shooter.ToString(), EnemiesSpawns[0]);
    }

    public void SpawnHealer()
    {
        EnemiesFactory.CreateEnemy(EnemyType.Healer.ToString(), EnemiesSpawns[Random.Range(0, EnemiesSpawns.Length)]);
    }
}
