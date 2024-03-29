using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Animations : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private P2Movement p2Movement;

    private bool atk1 = false;
    private bool atk2 = false;
    private bool atk3 = false;
    private bool hit = false;

    private enum MovementState { idle, walk, atk1, jump, fall, atk2, atk3, hit }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        p2Movement = GetComponent<P2Movement>();
    }

    void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (rb.velocity.x > 0f && p2Movement.IsGrounded())
        {
            state = MovementState.walk;
            sprite.flipX = false;
        }
        else if (rb.velocity.x < 0f && p2Movement.IsGrounded())
        {
            state = MovementState.walk;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (atk1)
        {
            state = MovementState.atk1;
        }

        if (atk2)
        {
            state = MovementState.atk2;
        }

        if (atk3)
        {
            state = MovementState.atk3;
        }

        if (rb.velocity.y > 0f)
        {
            state = MovementState.jump;
        }
        if (rb.velocity.y < 0f)
        {
            state = MovementState.fall;
        }

        if (hit)
        {
            state = MovementState.hit;
        }

        anim.SetInteger("state", (int)state);
    }

    public void IsAttacking1()
    {
        atk1 = true;
    }

    public void NotAttacking1()
    {
        atk1 = false;
    }

    public void IsAttacking2()
    {
        atk2 = true;
    }

    public void NotAttacking2()
    {
        atk2 = false;
    }

    public void IsAttacking3()
    {
        atk3 = true;
    }

    public void NotAttacking3()
    {
        atk3 = false;
    }

    public void IsHit()
    {
        hit = true;
    }

    public void NotHit()
    {
        hit = false;
    }
}
