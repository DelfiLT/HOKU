using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : PowerUps
{
    public override string powerUpName => PowerUpType.Damage.ToString();
    [SerializeField] private Sprite damageSprite;

    public override void Activate()
    {
        StartCoroutine(ActiveDamage());
    }

    IEnumerator ActiveDamage()
    {
        player.GetComponent<PlayerShooting>().DamageBoost = true;
        player.GetComponent<PlayerShooting>().powerUpSprite.enabled = true;
        player.GetComponent<PlayerShooting>().powerUpSprite.sprite = damageSprite;
        this.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(5);
        player.GetComponent<PlayerShooting>().powerUpSprite.enabled = false;
        Destroy(gameObject);
    }
}
