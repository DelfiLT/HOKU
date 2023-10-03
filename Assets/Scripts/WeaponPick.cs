using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPick : MonoBehaviour
{
    [SerializeField] private WeaponType weaponType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Iweapon>() != null)
        {
            collision.gameObject.GetComponent<Iweapon>().PickWeapon(weaponType);
            Destroy(this.gameObject);
        }
    }
}
