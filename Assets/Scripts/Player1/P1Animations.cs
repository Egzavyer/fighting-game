using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Animations : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private P1Movement p1Movement;

    private bool jab = false;
    private bool punch = false;
    private bool kick = false;

    private enum MovementState { idle, walk, jab, jump, fall, punch, kick }
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        p1Movement = GetComponent<P1Movement>();
    }

    void Update()
    {
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (rb.velocity.x > 0f && p1Movement.IsGrounded())
        {
            state = MovementState.walk;
            sprite.flipX = false;
        }
        else if (rb.velocity.x < 0f && p1Movement.IsGrounded())
        {
            state = MovementState.walk;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (jab)
        {
            state = MovementState.jab;
        }

        if (punch)
        {
            state = MovementState.punch;
        }

        if (kick)
        {
            state = MovementState.kick;
        }

        if (rb.velocity.y > 0f)
        {
            state = MovementState.jump;
        }
        if (rb.velocity.y < 0f)
        {
            state = MovementState.fall;
        }

        anim.SetInteger("state", (int)state);
    }

    public void IsJabbing()
    {
        jab = true;
    }

    public void NotJabbing()
    {
        jab = false;
    }

    public void IsPunching()
    {
        punch = true;
    }

    public void NotPunching()
    {
        punch = false;
    }

    public void IsKicking()
    {
        kick = true;
    }

    public void NotKicking()
    {
        kick = false;
    }
}
