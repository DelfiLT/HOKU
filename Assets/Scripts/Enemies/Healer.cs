using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Enemy
{
    public override string enemyName => EnemyType.Healer.ToString();

    private void Update()
    {
        target = GameObject.FindGameObjectWithTag("Enemy")?.transform;

        if (target != null)
        {
            distance = Vector2.Distance(target.transform.position, transform.position);
            if (distance > minRange && distance < maxRange)
            {
                Follow();
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().HP++;
        }
    }

}
