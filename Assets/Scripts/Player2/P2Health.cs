using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Health : MonoBehaviour
{
    private P2Animations p2Animations;
    [SerializeField] private float health = 100f;

    private void Start()
    {
        p2Animations = GetComponent<P2Animations>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        p2Animations.IsHit();
        Debug.Log("P2: " + health);
    }
}
