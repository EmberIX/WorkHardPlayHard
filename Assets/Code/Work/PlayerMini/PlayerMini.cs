using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMini : MonoBehaviour
{
    public PlayerMini_Control PC;
    public Rigidbody2D rb;
    public float currentSpeed;
    public Vector2 movement;

    private void Awake()
    {
        PC = new PlayerMini_Control();
    }
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);


        //movement = PC.PlayerMini.Movement.ReadValue<Vector2>();
        //PC.PlayerMini.Movement.started +=
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
        Debug.Log("move");
        //movement = direction;

        //rb.MovePosition(rb.position + direction * currentSpeed * Time.fixedDeltaTime);

        movement = context.ReadValue<Vector2>();
    }

    // Update is called once per frame
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
