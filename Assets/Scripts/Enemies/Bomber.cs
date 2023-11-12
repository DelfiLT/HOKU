using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy
{
    public override string enemyName => EnemyType.Bomber.ToString();

    private void Update()
    {
        Follow();
    }

    public override void Behaviour()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Behaviour();
        }
    }
}
