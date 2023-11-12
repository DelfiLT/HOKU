using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : Enemy
{
    public override string enemyName => EnemyType.Healer.ToString();

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Enemy")?.transform;
    }

    private void Update()
    {
        distance = Vector2.Distance(target.transform.position, transform.position);

        if (distance > minRange && distance < maxRange)
        {
            Follow();
        }
    }

    public override void Behaviour()
    {
        //helear enemigo
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Behaviour();
        }
    }
}
