using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shooter : Enemy
{
    public override string enemyName => EnemyType.Shooter.ToString();

    [SerializeField] private Transform bulletSpawn;
    private float shootTimer;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        distance = Vector2.Distance(target.transform.position, transform.position);

        shootTimer += Time.deltaTime;

        if (target != null)
        {
            distance = Vector2.Distance(target.transform.position, transform.position);
            if (distance > minRange && distance < maxRange)
            {
                Follow();
            }
        }

        if (distance <= maxRange)
        {
            if(shootTimer > 0.5f) 
            { 
                shootTimer = 0;
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(WeaponType.Shooter.ToString());

        if (bullet != null)
        {
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = bulletSpawn.rotation;
            bullet.SetActive(true);
        }
    }
}
