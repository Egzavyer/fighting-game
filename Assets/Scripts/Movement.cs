using UnityEngine;

public class Movement : MonoBehaviour
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
        if (gameObject.name == "Player1" && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }

        if (gameObject.name == "Player2" && Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (gameObject.name == "Player1")
        {
            if (Input.GetKey(KeyCode.D))
            {
                MoveRight();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                MoveLeft();
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        if (gameObject.name == "Player2")
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                MoveRight();
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                MoveLeft();
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }
    }
    private void MoveLeft()
    {
        rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
    }

    private void MoveRight()
    {
        rb.velocity = new Vector2(movementSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }

    }

    public bool IsGrounded()
    {
        //Checks if BoxCast is overlapping on Ground
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, ground);
    }
}