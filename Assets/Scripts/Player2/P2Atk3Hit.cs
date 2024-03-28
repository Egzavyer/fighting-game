using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Atk3Hit : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private P1Health p1Health;
    private void Start()
    {
        p1Health = player1.GetComponent<P1Health>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            p1Health.TakeDamage(30f);
        }
    }
}
