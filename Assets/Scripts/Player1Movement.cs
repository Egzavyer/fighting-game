using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float jumpHeight = 15.0f;

    [SerializeField] private LayerMask ground;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        //Attack Buttons
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveRight();
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    private void MoveLeft()
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
    }

    private void MoveRight()
    {
        rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

    }

    private bool IsGrounded()
    {
        //Checks if BoxCast is overlapping on Ground
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }
}
