using UnityEngine;

public class Atk2Hit : MonoBehaviour
{
    [SerializeField] private GameObject otherPlayer;
    private BoxCollider2D otherCollider;
    [SerializeField] private Health health;
    private void Start()
    {
        health = otherPlayer.GetComponent<Health>();
        otherCollider = otherPlayer.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == otherCollider)
        {
            health.TakeDamage(20f);
            Debug.Log(otherPlayer + ": " + health);
        }
    }
}