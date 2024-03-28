using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Atk2Hit : MonoBehaviour
{
    [SerializeField] private GameObject player2;
    [SerializeField] private P2Health p2Health;
    private void Start()
    {
        p2Health = player2.GetComponent<P2Health>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2"))
        {
            p2Health.TakeDamage(20f);
        }
    }
}
