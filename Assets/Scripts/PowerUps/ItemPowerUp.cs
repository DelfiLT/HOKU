using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPowerUp : MonoBehaviour
{
    public string objectName;
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.GetComponent<IpowerUp>() != null)
        {
            collision.gameObject.GetComponent<IpowerUp>().PickPowerUp(objectName);
            Destroy(this.gameObject);
        }
    }
}
