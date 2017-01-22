using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public float MaxSpeed = 12;
    public float MaxTurnSpeed = 65;
    public AudioSource pingSound;
    public AudioSource pickupSound;

    private CharacterController controller;
    private ParticleSystem particles;
    private ScannerEffect sonar;
    
    void Awake()
    {
        controller = GetComponent<CharacterController>();
        particles = GetComponentInChildren<ParticleSystem>();
        sonar = GetComponentInChildren<ScannerEffect>();
    }

    // Value between 0 - 1
    public void Move(float input)
    {
        input = Mathf.Clamp01(input);
        controller.Move(transform.forward * Time.deltaTime * MaxSpeed * input);
    }

    // Value between -1 - 1
    public void Turn(float input)
    {
        input = Mathf.Clamp(input, -1, 1);
        transform.Rotate(transform.up, MaxTurnSpeed * input * Time.deltaTime);
    }

    public void SonarPing()
    {
        if (!sonar.Scanning)
        {
            sonar.Scan();
            pingSound.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // If thing is a powerup
        // tell power up to be collected
        Pickup pickup = other.GetComponent<Pickup>();
        if (pickup != null)
        {
            pickup.Vanish(other.transform.position + Vector3.down * 10);
            particles.Play();
            pickupSound.Play();
        }
            
    }
}
