﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMini : MonoBehaviour
{
    public PlayerMini_Control PC;
    public Rigidbody2D rb;
    public float currentSpeed;
    public Vector2 movement;
    public Enemy_HP EH;
    public PlayerMini_HP PMH;

    private void Awake()
    {
        PC = new PlayerMini_Control();
    }

    void Start()
    {
        TryGetComponent(out rb);
        PMH = GetComponentInParent<PlayerMini_HP>();
    }

    private void OnEnable()
    {
        PC.PlayerMini.Movement.performed += Move;
        PC.Enable();
    }

    private void OnDisable()
    {
        PC.PlayerMini.Movement.performed -= Move;
        PC.Disable();
    }

    private void Move(InputAction.CallbackContext context)
    {
        if(PMH.HP > 0 || EH.HP > 0)
        movement = context.ReadValue<Vector2>();
    }

    void Update()
    {
        //PC.PlayerMini.Movement.performed += ctx => Move(ctx.ReadValue<Vector2>());
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
        //transform.position += new Vector3(movement.x * Time.deltaTime * currentSpeed, 0, movement.y * Time.deltaTime * currentSpeed);
    }
    private void FixedUpdate()
    {

    }
}
