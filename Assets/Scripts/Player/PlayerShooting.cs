using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour, Iweapon
{
    private string bulletName;
    public Transform spawn;

    [SerializeField] List<Sprite> weaponSprites;
    [SerializeField] private SpriteRenderer weaponSprite;
    [SerializeField] private AudioSource shootSound;

    private PlayerInputs playerInput;

    private void Start()
    {
        playerInput = new PlayerInputs();
        playerInput.Player.Enable();
        playerInput.Player.Shoot.performed += Shoot;
        weaponSprite.enabled = false;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(bulletName != "")
        {
            SpawnBullet();
        } 
        else
        {
            Debug.Log("You have no weapon equiped");
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
            shootSound.Play();
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
