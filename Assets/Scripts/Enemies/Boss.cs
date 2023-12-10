using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour, IgetDamagedInterface
{
    private float distance;
    private float shootTime;
    private float cannonTime;
    private int rotateSpeed = 5;

    private bool shootLeft = true;
    
    private Transform player;

    [SerializeField] private float bossHp;
    [SerializeField] private float range;
    [SerializeField] private AudioClip explotionClip;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] Transform cannonLeftSpawn;
    [SerializeField] Transform cannonRightSpawn;

    void Start()
    {
        shootTime = 0;
        cannonTime = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        RotateTowarsTarget();

        shootTime += Time.deltaTime;
        cannonTime += Time.deltaTime;

        if (player != null)
        {
            distance = Vector2.Distance(player.transform.position, transform.position);

            if (distance < range && shootTime > 1f)
            {
                shootTime = 0;
                BossShoot(WeaponType.Boss, bulletSpawn);
            }

            if(distance < range && cannonTime > 2f)
            {
                cannonTime = 0;
                if(shootLeft)
                {
                    BossShoot(WeaponType.Cannon, cannonLeftSpawn);
                }
                else
                {
                    BossShoot(WeaponType.Cannon, cannonRightSpawn);
                }
                shootLeft = !shootLeft;
            }
        }

        if (bossHp <= 0)
        {
            StartCoroutine(Victory());
        }
    }

    public void GetDamaged(int damage)
    {
        bossHp -= damage;
    }

    public void BossShoot(WeaponType bulletType, Transform bulletSpawn)
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPooledObject(bulletType.ToString());

        if (bullet != null)
        {
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = bulletSpawn.rotation;
            bullet.SetActive(true);
        }
    }

    protected void RotateTowarsTarget()
    {
        Vector2 targetDirection = player.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    IEnumerator Victory()
    {
        AudioManager.InstanceAudio.PlaySound(explotionClip);
        GameObject prefab = ParticlesObjectPool.ParticleInstance.GetPooledObject(ParticleTypes.ParticleExplotion.ToString());

        if (prefab != null)
        {
            prefab.transform.position = transform.position;
            prefab.transform.rotation = transform.rotation;
            prefab.SetActive(true);
        }

        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(3);
    }
}
