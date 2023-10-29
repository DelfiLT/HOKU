using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour, Iweapon
{
    private string bulletName;
    public Transform spawn;

    [SerializeField] private SpriteRenderer weaponSprite;
    [SerializeField] List<Sprite> weaponSprites;

    private PlayerInputs playerInput;

    private void Start()
    {
        playerInput = new PlayerInputs();
        playerInput.Player.Enable();
        playerInput.Player.Shoot.performed += Shoot;
        weaponSprite.enabled = false;
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

    public void PickWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.AutoCannon:
                StartCoroutine(LoadWeapon("ACBullet", 0));
                break;
            case WeaponType.BigSpace:
                StartCoroutine(LoadWeapon("BSBullet", 1));
                break;
            case WeaponType.Rockets:
                StartCoroutine(LoadWeapon("RBullet", 2));
                break;
            case WeaponType.Zapper:
                StartCoroutine(LoadWeapon("ZBullet", 3));
                break;
            default:
                break;
        }
    }

    IEnumerator LoadWeapon(string name, int weaponNum)
    {
        bulletName = name;
        weaponSprite.enabled = true;
        weaponSprite.sprite = weaponSprites[weaponNum];
        yield return new WaitForSeconds(30);
        bulletName = "";
        weaponSprite.enabled = false;
    }
}
