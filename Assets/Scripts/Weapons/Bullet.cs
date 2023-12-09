using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Config")]
    public WeaponType weaponType;
    public int poolAmmount;
    public GameObject particles;

    [Header("Bullet Stats")]
    [SerializeField] private int damage;
    private int boostedDamage;
    [SerializeField] private float bulletForce;

    private int rotateSpeed = 10;
    private Transform player;

    public int Damage { get { return damage; } set {  damage = value; } }
    public int BoostedDamage { get { return boostedDamage; } set { boostedDamage = value; } }

    private void Awake()
    {
        boostedDamage = damage * 2;    

        if(weaponType == WeaponType.Cannon)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    void Update()
    {
        if (weaponType == WeaponType.Cannon)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, bulletForce * Time.deltaTime);

            Vector2 targetDirection = player.position - transform.position;
            float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
        } 
        else
        {
            transform.Translate(Vector2.up * bulletForce * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BorderCollider"))
        {
            this.gameObject.SetActive(false);
        }

        if(collision.gameObject.CompareTag("bullet") && weaponType == WeaponType.Cannon)
        {
            this.gameObject.SetActive(false);
            Instantiate(particles, transform.position, Quaternion.identity);
        }

        if (collision.gameObject.GetComponent<IgetDamagedInterface>() != null)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
            collision.gameObject.GetComponent<IgetDamagedInterface>().GetDamaged(damage);
        }
    }
}
