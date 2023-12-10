using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPick : MonoBehaviour
{
    [SerializeField] private WeaponType weaponType;
    [SerializeField] private float shootTime;
    [SerializeField] private AudioClip pickSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Iweapon>() != null)
        {
            collision.gameObject.GetComponent<Iweapon>().PickWeapon(weaponType, shootTime);
            AudioManager.InstanceAudio.PlaySound(pickSound);
            Destroy(this.gameObject);
            GameObject prefab = ParticlesObjectPool.ParticleInstance.GetPooledObject(ParticleTypes.ParticleWeapon.ToString());
            if (prefab != null)
            {
                prefab.transform.position = transform.position;
                prefab.transform.rotation = transform.rotation;
                prefab.SetActive(true);
            }
        }
    }
}
