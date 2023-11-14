using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Heal : PowerUps
{
    [SerializeField] protected GameObject particle;
    public override string powerUpName => PowerUpType.Heal.ToString();
    
    public int healBoost;

    public override void Activate()
    {
        player.GetComponent<PlayerHP>().HP = player.GetComponent<PlayerHP>().HP + healBoost;
        Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
