using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;
    private float time = 30f;

    void Start()
    {

    }


    void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            timerText.text = time.ToString("00");
        }
    }
}
