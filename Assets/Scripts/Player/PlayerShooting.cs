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
    private float shootTime;
    private float timer;
    [SerializeField] private AudioClip ShootClip;

    [Header("PowerUp")]
    public SpriteRenderer powerUpSprite;

    private PlayerInputs playerInput;
    private bool damageBoost;
    public bool DamageBoost { get { return damageBoost; } set { damageBoost = value; } }

    private void Start()
    {
        shootTime = 0;
        playerInput = new PlayerInputs();
        playerInput.Player.Enable();
        playerInput.Player.Shoot.performed += Shoot;
        weaponSprite.enabled = false;
    }

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(bulletName != "" && bulletName != null)
        {
            if(timer > shootTime)
            {
                timer = 0;
                SpawnBullet();
                AudioManager.InstanceAudio.PlaySound(ShootClip);
            }
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
            Bullet bulletScript = bullet.GetComponent<Bullet>();

            if (damageBoost)
            {
                bulletScript.Damage = bulletScript.BoostedDamage;
            }
            else
            {
                bulletScript.Damage = bulletScript.Damage;
            }

            bullet.SetActive(true);
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = bulletSpawn.rotation;
        } 
    }

    public void PickWeapon(WeaponType weaponType, float shootTimer)
    {
        shootTime = shootTimer;
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
