using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ParticlesScript : MonoBehaviour
{
    public ParticleTypes particleType;
    public int poolAmmount;

    private void Update()
    {
        StartCoroutine(Particleoff());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BorderCollider"))
        {
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator Particleoff()
    {
        yield return new WaitForSeconds(1);
        this.gameObject.SetActive(false);
        Particleoff();
    }
}


