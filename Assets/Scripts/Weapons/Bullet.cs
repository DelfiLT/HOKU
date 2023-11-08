using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public WeaponType weaponType;
    public int poolAmmount;

    [SerializeField] float bulletForce;

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
    }
}
