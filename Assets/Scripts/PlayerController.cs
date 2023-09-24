using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB2D;

    void Start()
    {
        playerRB2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        float movY = Input.GetAxis("Vertical");

        Movement(movX, movY);
    }

    void Movement(float movX, float movY)
    {
        Vector2 direction = new Vector2(movX, movY);

        playerRB2D.AddForce(direction);
    }
}
