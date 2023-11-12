using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract string enemyName { get; }

    [Header("Enemy Stats")]
    [SerializeField] protected float hp;
    [SerializeField] protected float velocity;
    [SerializeField] protected float minRange;
    [SerializeField] protected float maxRange;

    protected Transform target;
    protected float distance;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    public abstract void Behaviour();

    protected void Follow()
    {
        distance = Vector2.Distance(target.transform.position, transform.position);

        if (distance > minRange && distance < maxRange)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, target.position, velocity * Time.deltaTime);
        }
    }

}
