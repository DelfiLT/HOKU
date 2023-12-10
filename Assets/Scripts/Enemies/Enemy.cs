using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using static UnityEngine.UI.Image;

public abstract class Enemy : MonoBehaviour
{
    public abstract string enemyName { get; }
    public float HP { get { return hp; } set { hp = value; } }

    [Header("Enemy Stats")]
    [SerializeField] protected float hp;
    protected float maxHP;
    [SerializeField] protected float velocity;
    [SerializeField] protected float minRange;
    [SerializeField] protected float maxRange;
    [SerializeField] protected AudioClip dieAudio;

    protected int rotateSpeed = 10;
    protected Transform target;
    protected float distance;

    protected void Follow()
    {
        if (target != null)
        {
            distance = Vector2.Distance(target.transform.position, transform.position);
            if (distance > minRange && distance < maxRange)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, target.position, velocity * Time.deltaTime);
            }
        }
    }
    protected void Die() 
    {
        Destroy(gameObject);
        AudioManager.InstanceAudio.PlaySound(dieAudio);
    }

    protected void RotateTowarsTarget()
    {
        if (target != null)
        {
            Vector2 targetDirection = target.position - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
        }
    }
}
