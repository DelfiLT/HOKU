using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy
{
    public override string enemyName => EnemyType.Bomber.ToString();

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    private void Update()
    {
        distance = Vector2.Distance(target.transform.position, transform.position);

        if (target != null)
        {
            distance = Vector2.Distance(target.transform.position, transform.position);
            if (distance > minRange && distance < maxRange)
            {
                Follow();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
