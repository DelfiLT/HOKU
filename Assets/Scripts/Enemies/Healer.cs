using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Enemy, IgetDamagedInterface
{
    public override string enemyName => EnemyType.Healer.ToString();

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Enemy")?.transform;
        Follow();

        if (hp <= 0)
        {
            Die();
        }
    }

    public void GetDamaged(int damage)
    {
        hp -= damage;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().HP++;
        }
    }
}
