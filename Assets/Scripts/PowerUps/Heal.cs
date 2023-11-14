using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : PowerUps
{
    public override string powerUpName => PowerUpType.Heal.ToString();
    public int healBoost;

    public override void Activate()
    {
        player.GetComponent<PlayerHP>().HP = player.GetComponent<PlayerHP>().HP + healBoost;
        //instanciar particulas para helear
        Destroy(gameObject);
    }
}
