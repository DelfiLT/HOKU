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
        this.GetComponent<SpriteRenderer>().enabled = false;

        playerShooting.DamageBoost = true;
        playerShooting.powerUpSprite.enabled = true;
        playerShooting.powerUpSprite.sprite = damageSprite;

        yield return new WaitForSeconds(5);

        playerShooting.DamageBoost = false;
        playerShooting.powerUpSprite.enabled = false;

        Destroy(gameObject);
    }
}
