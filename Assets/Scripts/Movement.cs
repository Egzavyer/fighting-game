using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float jumpHeight = 15.0f;

    [SerializeField] private LayerMask ground;

    private float rightEdge;
    private float leftEdge;
    private bool leftObstructed = false;
    private bool rightObstructed = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        rightEdge = (coll.size.x * 0.5f) - coll.offset.x;
        leftEdge = -rightEdge;
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

        if (gameObject.name == "Player1")
        {
            if (Input.GetKey(KeyCode.D) && !rightObstructed)
            {
                MoveRight();
            }
            else if (Input.GetKey(KeyCode.A) && !leftObstructed)
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
            if (Input.GetKey(KeyCode.RightArrow) && !rightObstructed)
            {
                MoveRight();
            }
            else if (Input.GetKey(KeyCode.LeftArrow) && !leftObstructed)
            {
                MoveLeft();
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        IsObstructed();
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

    public void IsObstructed()
    {
        RaycastHit2D rightRay = Physics2D.Raycast(transform.position + new Vector3(rightEdge + 0.01f, 0, 0), Vector2.right, 0.1f);
        RaycastHit2D leftRay = Physics2D.Raycast(transform.position + new Vector3(leftEdge - 0.01f, 0, 0), Vector2.left, 0.1f);

        if (rightRay)
        {
            rightObstructed = true;
        }
        else
        {
            rightObstructed = false;
        }

        if (leftRay)
        {
            leftObstructed = true;
        }
        else
        {
            leftObstructed = false;
        }
    }
}