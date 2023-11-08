using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract string enemyName { get; }
    public abstract int hp { get; }

    public abstract float velocity { get; }
    public abstract float minRange { get; }
    public abstract float maxRange { get; }
    //public abstract Transform spawn { get; }
    //public abstract Transform target { get; }

    public abstract void Behaviour();

    //protected void Follow()
    //{
    //    transform.position = Vector2.MoveTowards(this.transform.position, target.position, velocity * Time.deltaTime);
    //}

}
