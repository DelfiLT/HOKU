using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPick : MonoBehaviour
{
    [SerializeField] private WeaponType weaponType;
    [SerializeField] private float shootTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Iweapon>() != null)
        {
            collision.gameObject.GetComponent<Iweapon>().PickWeapon(weaponType, shootTime);
            Destroy(this.gameObject);
        }
    }
}
