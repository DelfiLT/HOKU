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
            Debug.Log("colisione holaa");
            collision.gameObject.GetComponent<Iweapon>().PickWeapon(weaponType);
            Destroy(this.gameObject);
        }
    }
}
