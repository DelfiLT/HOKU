using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour, Iweapon
{

    private GameObject bullet;
    private Rigidbody bulletRB;
    [SerializeField] private float bulletSpeed;
    public Transform spawn;
    private PlayerInputs playerInput;


    private void Start()
    {
        playerInput = new PlayerInputs();
        playerInput.Player.Enable();
        playerInput.Player.Shoot.performed += Shoot;
    }
    void Update()
    {
        //Shoot();
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
            bulletRB.AddRelativeForce(Vector2.up * bulletSpeed);
        }
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        SpawnBullet();
    }
}
