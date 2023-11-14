using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Bullet : MonoBehaviour
{
    public WeaponType weaponType;
    public int poolAmmount;
    public GameObject particles;
    [SerializeField] private int damage;
    [SerializeField] private float bulletForce;

    public int Damage { get { return damage; } set {  damage = value; } }

    void Update()
    {
        transform.Translate(Vector2.up * bulletForce * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BorderCollider"))
        {
            this.gameObject.SetActive(false);
        }

        if (collision.gameObject.GetComponent<IgetDamagedInterface>() != null)
        {
            Instantiate(particles, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
            collision.gameObject.GetComponent<IgetDamagedInterface>().GetDamaged(damage);
        }
    }
}
