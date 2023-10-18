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
    public GameObject prefab;
    public Transform spawn;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        playerInput = new PlayerInputs();
        playerInput.Player.Enable();
        playerInput.Player.Walk.performed += Walk;
        playerInput.Player.Shoot.performed += Shoot;

    }

    private void Walk(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb2D.velocity = movement * speed;
    }

    void Shoot(InputAction.CallbackContext context) 
    {
       Instantiate(prefab,spawn.position,spawn.rotation);

    }

}
