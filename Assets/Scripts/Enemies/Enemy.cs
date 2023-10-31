using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract string skillName { get; }
    public abstract float hp { get; }
    public abstract float damage { get; }
    public abstract float velocity { get; }
    public abstract float minRange { get; }
    public abstract float maxRange { get; }
    public abstract Transform spawn {  get; }
    public abstract Transform player { get; }

    public abstract void FollowPlayer();
    public abstract void Attack();
}
