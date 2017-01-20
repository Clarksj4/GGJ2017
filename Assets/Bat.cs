using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public float MaxSpeed = 12;
    public float MaxTurnSpeed = 65;

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
}
