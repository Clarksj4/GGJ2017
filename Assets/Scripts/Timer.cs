using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        if (timeLeft <= 0)
        {
            SceneManager.GetActiveScene(); SceneManager.LoadScene("LevelGood");
        }
        timeDisplay.text = timeLeft.ToString("0");
    }
}
