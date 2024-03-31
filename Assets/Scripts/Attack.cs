using UnityEngine;

public class Attack : MonoBehaviour
{
    private BoxCollider2D atk1HitboxColl;
    private BoxCollider2D atk2HitboxColl;
    private BoxCollider2D atk3HitboxColl;
    private Animations animations;
    private Movement Movement;
    void Start()
    {
        atk1HitboxColl = transform.Find("Atk1Hitbox").GetComponent<BoxCollider2D>();
        atk2HitboxColl = transform.Find("Atk2Hitbox").GetComponent<BoxCollider2D>();
        atk3HitboxColl = transform.Find("Atk3Hitbox").GetComponent<BoxCollider2D>();

        animations = GetComponent<Animations>();
        Movement = GetComponent<Movement>();
    }

    void Update()
    {
        if (gameObject.name == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.Z) && Movement.IsGrounded())
            {
                Invoke(nameof(ActivateAtk1Hitbox), 0.1f);
                DeactivateAtk2Hitbox();
                DeactivateAtk3Hitbox();
            }

            if (Input.GetKeyDown(KeyCode.X) && Movement.IsGrounded())
            {
                Invoke(nameof(ActivateAtk2Hitbox), 0.1f);
                DeactivateAtk1Hitbox();
                DeactivateAtk3Hitbox();
            }

            if (Input.GetKeyDown(KeyCode.C) && Movement.IsGrounded())
            {
                Invoke(nameof(ActivateAtk3Hitbox), 0.1f);
                DeactivateAtk1Hitbox();
                DeactivateAtk2Hitbox();
            }
        }

        if (gameObject.name == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.M) && Movement.IsGrounded())
            {
                Invoke(nameof(ActivateAtk1Hitbox), 0.1f);
                DeactivateAtk2Hitbox();
                DeactivateAtk3Hitbox();
            }

            if (Input.GetKeyDown(KeyCode.Comma) && Movement.IsGrounded())
            {
                Invoke(nameof(ActivateAtk2Hitbox), 0.1f);
                DeactivateAtk1Hitbox();
                DeactivateAtk3Hitbox();
            }

            if (Input.GetKeyDown(KeyCode.Period) && Movement.IsGrounded())
            {
                Invoke(nameof(ActivateAtk3Hitbox), 0.1f);
                DeactivateAtk1Hitbox();
                DeactivateAtk2Hitbox();
            }
        }
    }

    private void ActivateAtk1Hitbox()
    {
        atk1HitboxColl.enabled = true;
        animations.IsAttacking1();
    }

    public void DeactivateAtk1Hitbox()
    {
        atk1HitboxColl.enabled = false;
        animations.NotAttacking1();
    }

    private void ActivateAtk2Hitbox()
    {
        atk2HitboxColl.enabled = true;
        animations.IsAttacking2();
    }

    public void DeactivateAtk2Hitbox()
    {
        atk2HitboxColl.enabled = false;
        animations.NotAttacking2();
    }

    private void ActivateAtk3Hitbox()
    {
        atk3HitboxColl.enabled = true;
        animations.IsAttacking3();
    }

    public void DeactivateAtk3Hitbox()
    {
        atk3HitboxColl.enabled = false;
        animations.NotAttacking3();
    }
}