using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Atk : MonoBehaviour
{
    private BoxCollider2D atk1HitboxColl;
    private BoxCollider2D atk2HitboxColl;
    private BoxCollider2D atk3HitboxColl;
    private P2Animations p2Animations;
    private P2Movement p2Movement;
    void Start()
    {
        atk1HitboxColl = transform.Find("Atk1Hitbox").GetComponent<BoxCollider2D>();
        atk2HitboxColl = transform.Find("Atk2Hitbox").GetComponent<BoxCollider2D>();
        atk3HitboxColl = transform.Find("Atk3Hitbox").GetComponent<BoxCollider2D>();

        p2Animations = GetComponent<P2Animations>();
        p2Movement = GetComponent<P2Movement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && p2Movement.IsGrounded())
        {
            Invoke(nameof(ActivateAtk1Hitbox), 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.Comma) && p2Movement.IsGrounded())
        {
            Invoke(nameof(ActivateAtk2Hitbox), 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.Period) && p2Movement.IsGrounded())
        {
            Invoke(nameof(ActivateAtk3Hitbox), 0.1f);
        }
    }

    private void ActivateAtk1Hitbox()
    {
        atk1HitboxColl.enabled = true;
        p2Animations.IsAttacking1();
    }

    public void DeactivateAtk1Hitbox()
    {
        atk1HitboxColl.enabled = false;
        p2Animations.NotAttacking1();
    }

    private void ActivateAtk2Hitbox()
    {
        atk2HitboxColl.enabled = true;
        p2Animations.IsAttacking2();
    }

    public void DeactivateAtk2Hitbox()
    {
        atk2HitboxColl.enabled = false;
        p2Animations.NotAttacking2();
    }

    private void ActivateAtk3Hitbox()
    {
        atk3HitboxColl.enabled = true;
        p2Animations.IsAttacking3();
    }

    public void DeactivateAtk3Hitbox()
    {
        atk3HitboxColl.enabled = false;
        p2Animations.NotAttacking3();
    }
}
