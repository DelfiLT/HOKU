using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract string enemyName { get; }
    public abstract float hp { get; }
    public abstract float velocity { get; }
    public abstract float minRange { get; }
    public abstract float maxRange { get; }
    public abstract float distance { get; }
    public abstract Transform spawn {  get; }
    public abstract Transform target { get; }

    public abstract void Follow();
    public abstract void Attack();
}
