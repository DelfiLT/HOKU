using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Bomber : Enemy, IgetDamagedInterface
{
    public override string enemyName => EnemyType.Bomber.ToString();
    [SerializeField] private int explotionDamage;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
        maxHP = hp;
    }

    private void Update()
    {
        Follow();
        RotateTowarsTarget();

        if (hp > maxHP)
        {
            hp = maxHP;
        }

        if (hp <= 0)
        {
            Die();
        }
    }

    public void GetDamaged(int damage)
    {
        hp -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IgetDamagedInterface>().GetDamaged(explotionDamage);
            Die();
        }
    }
}
