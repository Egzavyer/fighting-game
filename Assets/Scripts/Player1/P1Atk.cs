using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Atk : MonoBehaviour
{
    private BoxCollider2D jabHitboxColl;
    private BoxCollider2D punchHitboxColl;
    private BoxCollider2D kickHitboxColl;
    private P1Animations p1Animations;
    private P1Movement p1Movement;
    void Start()
    {
        jabHitboxColl = transform.Find("JabHitbox").GetComponent<BoxCollider2D>();
        punchHitboxColl = transform.Find("PunchHitbox").GetComponent<BoxCollider2D>();
        kickHitboxColl = transform.Find("KickHitbox").GetComponent<BoxCollider2D>();

        p1Animations = GetComponent<P1Animations>();
        p1Movement = GetComponent<P1Movement>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && p1Movement.IsGrounded())
        {
            Invoke(nameof(ActivateJabHitbox), 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.X) && p1Movement.IsGrounded())
        {
            Invoke(nameof(ActivatePunchHitbox), 0.1f);
        }

        if (Input.GetKeyDown(KeyCode.C) && p1Movement.IsGrounded())
        {
            Invoke(nameof(ActivateKickHitbox), 0.1f);
        }
    }

    private void ActivateJabHitbox()
    {
        jabHitboxColl.enabled = true;
        p1Animations.IsJabbing();
    }

    public void DeactivateJabHitbox()
    {
        jabHitboxColl.enabled = false;
        p1Animations.NotJabbing();
    }

    private void ActivatePunchHitbox()
    {
        punchHitboxColl.enabled = true;
        p1Animations.IsPunching();
    }

    public void DeactivatePunchHitbox()
    {
        punchHitboxColl.enabled = false;
        p1Animations.NotPunching();
    }

    private void ActivateKickHitbox()
    {
        kickHitboxColl.enabled = true;
        p1Animations.IsKicking();
    }

    public void DeactivateKickHitbox()
    {
        kickHitboxColl.enabled = false;
        p1Animations.NotKicking();
    }
}
