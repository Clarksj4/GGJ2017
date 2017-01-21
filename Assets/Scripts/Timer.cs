using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public float timeLeft = 120.0f;
    public Text timeDisplay;

    void Start()
    {

    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        timeDisplay.text = timeLeft.ToString("0.00");
        if (timeLeft < 0)
        {

        }
    }
}
