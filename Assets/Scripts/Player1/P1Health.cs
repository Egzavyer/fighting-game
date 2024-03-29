using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Health : MonoBehaviour
{
    private P1Animations p1Animations;
    [SerializeField] private float health = 100f;

    private void Start()
    {
        p1Animations = GetComponent<P1Animations>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        p1Animations.IsHit();
        Debug.Log("P1: " + health);

    }
}
