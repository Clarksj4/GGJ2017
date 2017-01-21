using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public float MaxSpeed = 12;
    public float MaxTurnSpeed = 65;
    public float SonarSpeed = 50;
    public float SonarRange = 100;

    private Coroutine sonarPulse;

    private ScannerEffectDemo sonar;

    void Awake()
    {
        sonar = GetComponentInChildren<ScannerEffectDemo>();
    }

    // Value between 0 - 1
    public void Move(float input)
    {
        input = Mathf.Clamp01(input);
        transform.Translate(Vector3.forward * Time.deltaTime * MaxSpeed * input);
    }

    // Value between -1 - 1
    public void Turn(float input)
    {
        input = Mathf.Clamp(input, -1, 1);
        transform.Rotate(transform.up, MaxTurnSpeed * input * Time.deltaTime);
    }

    public void SonarPing()
    {
        if (sonarPulse == null)
            sonarPulse = StartCoroutine(PulseSonar());
    }

    void OnTriggerEnter(Collider other)
    {
        // If thing is a powerup
        // tell power up to be collected
        Pickup pickup = other.GetComponentInParent<Pickup>();
        if (pickup != null)
            pickup.Vanish(other.transform.position + Vector3.down * 10);
    }

    IEnumerator PulseSonar()
    {
        sonar.ScanDistance = 0;

        while (sonar.ScanDistance < SonarRange)
        {
            sonar.ScannerOrigin = transform;
            sonar.ScanDistance += Time.deltaTime * SonarSpeed;

            yield return null;
        }

        sonar.ScanDistance = 0;
        sonarPulse = null;
    }
}
