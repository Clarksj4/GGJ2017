using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightCycleController : MonoBehaviour {

    public Material mainSkybox;
    public Material almostDoneSkybox;
    public Material GameOverSkybox;

    public float timeLeft = 30.0f;

    void Start()
    {
        RenderSettings.skybox = mainSkybox;
    }
    void Update()
    {
        Debug.Log(timeLeft);
        timeLeft -= Time.deltaTime;
        if (timeLeft < 15 && timeLeft > 5)
        {
            Debug.Log("Time's almost up, homie!");
            RenderSettings.skybox = almostDoneSkybox;
        }
        if (timeLeft < 0)
        {
            Debug.Log("Nighty Night, little fella");
            //GameOver();
            RenderSettings.skybox = GameOverSkybox;
        }
    }
}
