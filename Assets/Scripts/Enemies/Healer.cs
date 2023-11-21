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
        RotateTowarsTarget();

        if (hp > 30)
        {
            hp = 30;
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
