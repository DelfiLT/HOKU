using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour, Iweapon
{
    [Header("Shoot config")]
    public Transform bulletSpawn;
    public SpriteRenderer weaponSprite;
    public List<Sprite> weaponSprites;
    private string bulletName;

    [Header("PowerUp")]
    public SpriteRenderer powerUpSprite;

    private PlayerInputs playerInput;
    private bool damageBoost;
    public bool DamageBoost { get { return damageBoost; } set { damageBoost = value; } }

    private void Start()
    {
        playerInput = new PlayerInputs();
        playerInput.Player.Enable();
        playerInput.Player.Shoot.performed += Shoot;
        weaponSprite.enabled = false;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(bulletName != "" && bulletName != null)
        {
            SpawnBullet();
        } 
        else
        {
            Debug.Log("No weapon equiped");
        }
    }

    public void SpawnBullet()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(bulletName);

        if (bullet != null)
        {
            if (damageBoost)
            {
                bullet.GetComponent<Bullet>().Damage = 4;
            }
            else
            {
                bullet.GetComponent<Bullet>().Damage = 2;
            }

            bullet.SetActive(true);
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = bulletSpawn.rotation;
        } 
    }

    public void PickWeapon(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.AutoCannon:
                StartCoroutine(LoadWeapon(WeaponType.AutoCannon.ToString(), 0));
                break;
            case WeaponType.BigSpace:
                StartCoroutine(LoadWeapon(WeaponType.BigSpace.ToString(), 1));
                break;
            case WeaponType.Rockets:
                StartCoroutine(LoadWeapon(WeaponType.Rockets.ToString(), 2));
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
