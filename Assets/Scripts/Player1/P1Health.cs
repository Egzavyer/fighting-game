using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private float health = 100f;
    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
