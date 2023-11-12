using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public EnemiesFactory EnemiesFactory;

    public Transform ESLeft;
    public Transform ESBottom;
    public Transform ESRight;

    public void SpawnBomber()
    {
        EnemiesFactory.CreateEnemy(EnemyType.Bomber.ToString(), ESLeft);
    }
}
