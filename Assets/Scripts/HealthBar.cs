using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    private Health healthScript;
    public Image frontHealthbar;
    public Image backHealthbar;
    public TMP_Text healthbarText;

    public float chipSpeed = 2f;
    float lerpTimer;
    void Start()
    {
        healthScript = player.GetComponent<Health>();
    }

    void Update()
    {
        healthScript.health = Mathf.Clamp(healthScript.health, 0f, healthScript.maxHealth);
        UpdateHealthbarUI();
    }

    public void UpdateHealthbarUI()
    {
        float fillBack = backHealthbar.fillAmount;
        float healthFraction = healthScript.health / healthScript.maxHealth;

        if (fillBack > healthFraction)
        {
            lerpTimer = 0f;
            frontHealthbar.fillAmount = healthFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backHealthbar.fillAmount = Mathf.Lerp(fillBack, healthFraction, percentComplete);
            healthbarText.text = healthScript.health.ToString();
        }
    }
}
