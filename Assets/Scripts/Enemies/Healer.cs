using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Enemy, IgetDamagedInterface
{
    public override string enemyName => EnemyType.Healer.ToString();

    private void Awake()
    {
        maxHP = hp;
    }

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Enemy")?.transform;
        Follow();
        RotateTowarsTarget();

        if (hp > maxHP)
        {
            hp = maxHP;
        }

        if (hp <= 0)
        {
            Die();
            GameObject prefab = ParticlesObjectPool.ParticleInstance.GetPooledObject(ParticleTypes.ParticleHealer.ToString());

            if (prefab != null)
            {
                prefab.transform.position = transform.position;
                prefab.transform.rotation = transform.rotation;
                prefab.SetActive(true);
            }
        }
    }

    public void GetDamaged(int damage)
    {
        hp -= damage;
    }

    public void HealAlly(Collision2D collision)
    {
        collision.gameObject.GetComponent<Enemy>().HP++;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            HealAlly(collision);
        }
    }
}
