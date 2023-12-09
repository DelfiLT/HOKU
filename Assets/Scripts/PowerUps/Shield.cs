using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : PowerUps
{
    public override string powerUpName => PowerUpType.Shield.ToString();
    
    [SerializeField] private Sprite shieldSprite;

    public override void Activate()
    {
        StartCoroutine(ActiveShield());
    }

    IEnumerator ActiveShield()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;

        playerHp.ShieldActivated = true;
        playerShooting.powerUpSprite.enabled = true;
        playerShooting.powerUpSprite.sprite = shieldSprite;

        yield return new WaitForSeconds(5);

        playerHp.ShieldActivated = false;
        playerShooting.powerUpSprite.enabled = false;

        Destroy(gameObject);
    }
}
