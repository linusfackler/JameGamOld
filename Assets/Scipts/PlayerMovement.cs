using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    public Vector2 startPos;

    private float horizontal;
    public float speed = 5;
    public bool isFacingRight = true;

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

        private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
