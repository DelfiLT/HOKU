using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHP : MonoBehaviour, IpowerUp
{
    public int hp;

    public void PickOPowerUp(string objectName)
    {
        if (objectName == "Shield")
        {
            StartCoroutine(activeShield());
        }
    }

    IEnumerator activeShield()
    {
        hp = hp + 100;
        yield return new WaitForSeconds(10f);
    }
}
