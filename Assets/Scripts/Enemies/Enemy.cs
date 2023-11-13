using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract string enemyName { get; }
    public float HP { get { return hp; } set { hp = value; } }

    [Header("Enemy Stats")]
    [SerializeField] protected float hp;
    [SerializeField] protected float velocity;
    [SerializeField] protected float minRange;
    [SerializeField] protected float maxRange;

    protected Transform target;
    protected float distance;

    protected void Follow()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, target.position, velocity * Time.deltaTime);
    }

}
