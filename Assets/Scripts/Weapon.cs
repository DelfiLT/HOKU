using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, Iweapon
{

    public GameObject bullet;
    private Rigidbody bulletRB;
    public Transform spawn;

    void Update()
    {
        Shoot();
    }

    public void PickWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.AutoCannon:
                bullet = ObjectPool.SharedInstance.GetPooledObject("ACBullet");
                break;
            case WeaponType.BigSpace:
                bullet = ObjectPool.SharedInstance.GetPooledObject("BSBullet");
                break;
            case WeaponType.Rockets:
                bullet = ObjectPool.SharedInstance.GetPooledObject("RBullet");
                break;
            case WeaponType.Zapper:
                bullet = ObjectPool.SharedInstance.GetPooledObject("ZBullet");
                break;
            default:
                break;
        }
    }

    public void SpawnBullet()
    {
        if (bullet != null)
        {
            bulletRB = bullet.GetComponent<Rigidbody>();

            bullet.transform.position = spawn.position;
            bullet.transform.rotation = spawn.rotation;
            bullet.SetActive(true);
        }
    }

    public void Shoot()
    {
        if (Input.GetMouseButton(0))
        {
            
        }
    }
}
