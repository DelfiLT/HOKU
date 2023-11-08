using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomber : Enemy
{
    public override string enemyName => EnemyType.Bomber.ToString();
    public override int hp => 100;
    public override float velocity => 20;
    public override float minRange => 0;
    public override float maxRange => 10;

    public float distance;

    private void Update()
    {
        //if (target != null)
        //{
        //    distance = Vector2.Distance(target.position, spawn.position);
        //}
    }

    public override void Behaviour()
    {
        Destroy(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Behaviour();
        }
    }
}
