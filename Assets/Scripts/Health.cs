using UnityEngine;

public class Health : MonoBehaviour
{
    private Animations animations;
    [SerializeField] private float health = 100f;

    private void Start()
    {
        animations = GetComponent<Animations>();
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        animations.IsHit();
        Debug.Log(gameObject.name + ": " + health);
    }
}