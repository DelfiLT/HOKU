using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private Vector2 movement;
    [SerializeField] private float speed;
    private PlayerInputs playerInput;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerInput = new PlayerInputs();
        playerInput.Player.Enable();
        playerInput.Player.Walk.performed += Walk;
    }

    private void Walk(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb2D.velocity = movement * speed;
    }
}
