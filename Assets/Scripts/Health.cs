using UnityEngine;

public class Health : MonoBehaviour
{
    private Animations animations;
    public float health;
    public float maxHealth = 100f;

    private void Start()
    {
        animations = GetComponent<Animations>();

        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        animations.IsHit();
        Debug.Log(gameObject.name + ": " + health);
    }
}