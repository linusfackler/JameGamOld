using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 startPos;

    private float horizontal;
    public float speed = 3;
    public bool isFacingRight = true;
    public float jumpingPower = 3;

    void Start()
    {
        //transform.position = startPos;
    }

    void Update()
    {
        if (!isFacingRight && horizontal > 0f)
            Flip();
        else if (isFacingRight && horizontal < 0f)
            Flip();
    }

    void FixedUpdate()
    {
        print("horizontal: " + horizontal);
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (rb.velocity.y == 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
