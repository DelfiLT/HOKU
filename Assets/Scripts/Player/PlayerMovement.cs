using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField] private float speed;
    private PlayerInputs playerInput;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerInput = new PlayerInputs();
        playerInput.Player.Enable();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 movement = playerInput.Player.Walk.ReadValue<Vector2>();
        rb2D.velocity = new Vector2(movement.x, movement.y) * speed;
    }
}
