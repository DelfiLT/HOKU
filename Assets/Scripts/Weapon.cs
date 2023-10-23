using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour, Iweapon
{
    private string bulletName;
    public Transform spawn;

    private PlayerInputs playerInput;

    private void Start()
    {
        playerInput = new PlayerInputs();
        playerInput.Player.Enable();
        playerInput.Player.Shoot.performed += Shoot;
    }

    public void PickWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.AutoCannon:
                bulletName = "ACBullet";
                break;
            case WeaponType.BigSpace:
                bulletName = "BSBullet";
                break;
            case WeaponType.Rockets:
                bulletName = "RBullet";
                break;
            case WeaponType.Zapper:
                bulletName = "ZBullet";
                break;
            default:
                break;
        }
    }

    public void SpawnBullet()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(bulletName);
        if (bullet != null)
        {
            bullet.transform.position = spawn.position;
            bullet.transform.rotation = spawn.rotation;
            bullet.SetActive(true);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        SpawnBullet();
    }
}
