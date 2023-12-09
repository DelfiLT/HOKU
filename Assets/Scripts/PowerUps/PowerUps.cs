using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUps : MonoBehaviour
{
    public abstract string powerUpName { get; }

    protected GameObject player;
    protected PlayerHP playerHp;
    protected PlayerShooting playerShooting;

    public abstract void Activate();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerShooting = player.GetComponent<PlayerShooting>();
        playerHp = player.GetComponent<PlayerHP>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Activate();
        }
    }
}
