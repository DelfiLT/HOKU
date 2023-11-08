using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy
{
    [Header("Enemy Stats")]
    [SerializeField] private float bomberHp;
    [SerializeField] private float bomberVel;
    [SerializeField] private float bomberMinRange;
    [SerializeField] private float bomberMaxRange;
    [SerializeField] private float bomberDistance;

    [Header("Enemy Config")]
    [SerializeField] private Transform bomberSpawn;
    [SerializeField] private Transform targetTransform;
    public WeaponType type;

    public override string enemyName => "Bomber";
    public override float hp => bomberHp;
    public override float velocity => bomberVel;
    public override float minRange => bomberMinRange;
    public override float maxRange => bomberMaxRange;
    public override float distance => bomberDistance;
    public override Transform spawn => bomberSpawn;
    public override Transform target => targetTransform;

    private void Update()
    {
        if (targetTransform != null)
        {
            bomberDistance = Vector2.Distance(targetTransform.position, spawn.position);
        }
    }

    public override void Follow()
    {
        if(bomberDistance > minRange && bomberDistance < maxRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, targetTransform.position, bomberVel * Time.deltaTime);
        }
    }

    public override void Attack()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(type.ToString());

        if (bullet != null)
        {
            bullet.transform.position = spawn.position;
            bullet.transform.rotation = spawn.rotation;
            bullet.SetActive(true);
        }
    }
}
