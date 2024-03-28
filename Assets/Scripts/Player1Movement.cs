using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Movement : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float jumpHeight = 15.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
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
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}
