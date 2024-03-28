using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Atk : MonoBehaviour
{
    private BoxCollider2D hitboxColl;
    private SpriteRenderer fist;
    void Start()
    {
        hitboxColl = transform.Find("Atk1Hitbox").GetComponent<BoxCollider2D>();
        fist = transform.Find("Atk1Hitbox").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Invoke(nameof(ActivateHitbox), 0.1f);
            Invoke(nameof(DeactivateHitbox), 0.3f);
        }
    }

    void ActivateHitbox()
    {
        hitboxColl.enabled = true;
        fist.enabled = true;
    }

    void DeactivateHitbox()
    {
        hitboxColl.enabled = false;
        fist.enabled = false;
    }
}
