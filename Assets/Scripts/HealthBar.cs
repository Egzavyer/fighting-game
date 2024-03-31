using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject player;
    private Health healthScript;
    public Image frontHealthbar;
    public Image backHealthbar;

    public float chipSpeed = 2f;
    float lerpTimer;
    void Start()
    {
        healthScript = player.GetComponent<Health>();
    }

    void Update()
    {
        UpdateHealthbarUI();
    }

    public void UpdateHealthbarUI()
    {
        float fillFront = frontHealthbar.fillAmount;
        float fillBack = backHealthbar.fillAmount;

        float healthFraction = healthScript.health / healthScript.maxHealth;

        if (fillBack > healthFraction)
        {
            lerpTimer = 0f;
            frontHealthbar.fillAmount = healthFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            backHealthbar.fillAmount = Mathf.Lerp(fillBack, healthFraction, percentComplete);
        }
    }
}
