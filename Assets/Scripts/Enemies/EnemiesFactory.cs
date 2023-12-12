using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesFactory : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies;
    private Dictionary<string, Enemy> enemiesDictionary;

    private void Awake()
    {
        enemiesDictionary = new Dictionary<string, Enemy>();

        foreach (var enemy in enemies)
        {
            enemiesDictionary.Add(enemy.enemyName, enemy);
        }
    }

    public Enemy CreateEnemy(string enemyName, Transform spawn)
    {
        if (enemiesDictionary.TryGetValue(enemyName, out Enemy enemyPrefab))
        {
            Enemy enemyInstance = Instantiate(enemyPrefab, spawn.position, Quaternion.identity);
            return enemyInstance;
        }
        else
        {
            Debug.LogWarning($"The enemy '{enemyName}' doesnt exists in the enemies database");
            return null;
        }
    }
}
