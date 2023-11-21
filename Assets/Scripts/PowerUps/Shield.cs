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
        player.GetComponent<PlayerHP>().ShieldActivated = true;

        player.GetComponent<PlayerShooting>().powerUpSprite.enabled = true;
        player.GetComponent<PlayerShooting>().powerUpSprite.sprite = shieldSprite;
        this.GetComponent<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(5);

        player.GetComponent<PlayerHP>().ShieldActivated = false;

        player.GetComponent<PlayerShooting>().powerUpSprite.enabled = false;
        Destroy(gameObject);
    }
}
