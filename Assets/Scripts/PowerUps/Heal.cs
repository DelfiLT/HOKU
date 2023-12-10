using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Heal : PowerUps
{
    public override string powerUpName => PowerUpType.Heal.ToString();

    public int healBoost;

    public override void Activate()
    {
        playerHp.HP = playerHp.HP + healBoost;

        GameObject prefab = ParticlesObjectPool.ParticleInstance.GetPooledObject(ParticleTypes.ParticleHealiing.ToString());

        if (prefab != null)
        {
            prefab.transform.position = transform.position;
            prefab.transform.rotation = transform.rotation;
            prefab.SetActive(true);
        }

        Destroy(gameObject);
    }
}
